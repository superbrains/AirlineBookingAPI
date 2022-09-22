using AutoMapper;
using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Common.Enums;
using Data.Models;
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
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {          
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CreateUser(UserVM request)
        {
            //Check if User with same Email Exists
            var checkExist = await _unitOfWork.Users.FindOne(x => x.EmailAddress == request.EmailAddress);
            if (checkExist!=null)
            {
                throw new ApiException("Email address already exists");
            }
          
            var users = _mapper.Map<Users>(request);
     
            var result = await _unitOfWork.Users.Add(users);
            await _unitOfWork.CompleteAsync();

            if (result)
            {
              return new ApiResponse(request);
            }
            else
            {
                throw new ApiException(StatusCode.GeneralError);
            }           
        }

        public async Task<ApiResponse> GetUserProfile(string email)
        {
            var profile = await _unitOfWork.Users.GetByEmail(email);

            if (profile != null)
            {
                var user= _mapper.Map<UserVM>(profile);
                 return new ApiResponse(user);
            }

            throw new ApiException(StatusCode.NotFound);
        }

        public async Task<ApiResponse> ValidateUser(string email, string pass)
        {
            //Validate Email and Password
            var validLogin = await _unitOfWork.Users.FindOne(x => x.EmailAddress == email);
            if (validLogin == null)
            {
                throw new ApiException(StatusCode.NotFound);
            }
            else
            {
                var user = _mapper.Map<UserVM>(validLogin);
                return new ApiResponse(user);
            }
        }
    }
}
