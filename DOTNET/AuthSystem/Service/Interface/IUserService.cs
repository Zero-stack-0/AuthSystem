using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Dto.Response;

namespace AuthSystem.Service.Interface
{
    public interface IUserService
    {
        Task<UserResponse> GetUserById(int id);
    }
}