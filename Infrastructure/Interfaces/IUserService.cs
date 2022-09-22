using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<ApiResponse> CreateUser(UserVM request);
        Task<ApiResponse> ValidateUser(string email, string pass);   
        Task<ApiResponse> GetUserProfile(string email);
    }
}
