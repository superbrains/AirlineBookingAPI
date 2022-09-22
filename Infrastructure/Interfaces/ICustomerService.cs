using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface ICustomerService
    {
        Task<ApiResponse> CreateCustomer(CustomerVM request);
        Task<ApiResponse> GetCustomerInfo(string email);
    }
}
