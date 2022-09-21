using Common.DTOs.Request;
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
        public Task<CustomerVM> CreateCustomer(CustomerVM request)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerVM> GetCustomerInfo(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
