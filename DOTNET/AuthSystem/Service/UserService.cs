using AuthSystem.Dto.Request;
using AuthSystem.Dto.Response;
using AuthSystem.Model;
using AuthSystem.Repository.Interface;
using AuthSystem.Service.Helper;
using AuthSystem.Service.Interface;
using AutoMapper;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<ApiResponse> GetUserById(int id)
    {
        var user = await _userRepository.GetById(id);

        return new ApiResponse(_mapper.Map<UserResponse>(user), 200, "User");
    }

    public async Task<ApiResponse> CreateUser(CreateUserRequest userRequest)
    {
        if (await _userRepository.GetByEmail(userRequest.Email) is not null)
        {
            return new ApiResponse(null, 400, "Email already exists");
        }
        var user = new Users(userRequest.FirstName, userRequest.LastName, userRequest.Email, userRequest.Password);

        var userResponse = await _userRepository.CreateUser(user);
        return new ApiResponse(_mapper.Map<UserResponse>(userResponse), 200, "User created successfully");
    }

    public async Task<ApiResponse> GetByEmailAndPassword(string email, string password)
    {
        var user = await _userRepository.GetByEmailAndPassword(email, password);
        if (user is null)
        {
            return new ApiResponse(null, 400, "Invalid email or password");
        }
        return new ApiResponse(_mapper.Map<UserResponse>(user), 200, "User");
    }

    public async Task<ApiResponse> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);
        if (user is null)
        {
            return new ApiResponse(null, 400, "Invalid email or password");
        }
        return new ApiResponse(_mapper.Map<UserResponse>(user), 200, "User");
    }
}