using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Model;

namespace AuthSystem.Repository.Interface
{
    public interface IUserRepository
    {
        Task<Users?> GetById(long id);
        Task<Users?> CreateUser(Users user);
        Task<Users?> GetByEmail(string email);
    }
}