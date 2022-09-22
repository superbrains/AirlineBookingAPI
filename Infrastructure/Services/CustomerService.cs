using AutoMapper;
using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Common.Enums;
using Common.Extensions;
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
    public class CustomerService : ICustomerService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> CreateCustomer(CustomerVM request)
        {
            //Check if User with same Email Exists
            var checkExist = await _unitOfWork.Customer.FindOne(x => x.EmailAddress == request.EmailAddress);
            if (checkExist != null)
            {
                throw new ApiException("Email address already exists");
            }

            var customer = _mapper.Map<Customer>(request);

            var result = await _unitOfWork.Customer.Add(customer);
            await _unitOfWork.CompleteAsync();

            if (result)
            {
                return new ApiResponse(request);
            }
            else
            {
                throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.GeneralError));
            }
        }

        public async Task<ApiResponse> GetCustomerInfo(string email)
        {
            var profile = await _unitOfWork.Customer.GetByEmail(email);

            if (profile != null)
            {
                var customer = _mapper.Map<CustomerVM>(profile);
                return new ApiResponse(customer);
            }

            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.NotFound));
        }
    }
}
