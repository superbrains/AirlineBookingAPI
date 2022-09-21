using Common.DTOs.Request;
using Data.Transactions;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {          
            _unitOfWork = unitOfWork;
        }

        public async Task<UserVM> CreateUser(UserVM request)
        {
            //await _unitOfWork.Users.Add(user);

            //await _unitOfWork.CompleteAsync();

            throw new NotImplementedException();
        }

        public Task<UserVM> GetUserProfile(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserVM> ValidateUser(string email, string pass)
        {
            throw new NotImplementedException();
        }
    }
}
