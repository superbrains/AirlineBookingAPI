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
        Task<UserVM> CreateUser(UserVM request);
        Task<UserVM> ValidateUser(string email, string pass);   
        Task<UserVM> GetUserProfile(string email);
    }
}
