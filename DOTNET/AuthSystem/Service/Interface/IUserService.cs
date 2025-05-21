using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthSystem.Dto.Request;
using AuthSystem.Dto.Response;
using AuthSystem.Service.Helper;

namespace AuthSystem.Service.Interface
{
    public interface IUserService
    {
        Task<ApiResponse> GetUserById(int id);
        Task<ApiResponse> CreateUser(CreateUserRequest userRequest);
    }
}