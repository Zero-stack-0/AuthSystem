using AuthSystem.Dto.Request;
using AuthSystem.Model;
using AuthSystem.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuthSystem.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AuthSystemDbContext _context;
        public UserRepository(AuthSystemDbContext context)
        {
            _context = context;
        }
        public Task<Users?> GetById(long id)
        {
            var user = _context.Users
                .Where(x => x.Id == id)
                .FirstOrDefaultAsync();

            return user;
        }

        public Task<Users?> GetByEmail(string email)
        {
            var user = _context.Users
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();

            return user;
        }

        public Task<Users?> CreateUser(Users user)
        {
            _context.Users.Add(user);
            var result = _context.SaveChangesAsync();

            if (result.Result > 0)
            {
                return Task.FromResult(user);
            }
            else
            {
                return Task.FromResult<Users?>(null);
            }
        }
    }
}