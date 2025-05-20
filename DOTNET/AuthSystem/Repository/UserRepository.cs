using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}