using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthSystem.Dto.Request;
using AuthSystem.Model;
using AuthSystem.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using AuthSystem.Dto.Response;
using Microsoft.IdentityModel.Tokens;
using AuthSystem.Service.Helper;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace AuthSystem.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest userRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(await _userService.CreateUser(userRequest));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetByEmailAndPassword(loginRequest.Email, loginRequest.Password);
            if (user == null)
            {
                return Ok(new ApiResponse(null, 401, "Invalid email or password"));

            }
            var UserResponse = (UserResponse)user.Data;

            var token = GenerateToken(UserResponse.Email, "User");

            return Ok(new ApiResponse(token, 200, "Login successful"));
        }

        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> GetUserProfile()
        {
            var username = User.FindFirst(ClaimTypes.Name)?.Value;
            var role = User.FindFirst(ClaimTypes.Role)?.Value;
            if (username == null || role == null)
            {
                return Ok(new ApiResponse(null, 401, "Unauthorized"));
            }
            var data = await _userService.GetByEmail(username);
            return Ok(data);
        }

        public string GenerateToken(string username, string role)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"])); // should be in config
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["issuer"],
                audience: jwtSettings["audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}