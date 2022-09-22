using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        public CustomersController(ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService; 
        }

        [HttpPost(Name = "Register")]
        public async Task<ApiResponse> Register(CustomerVM request)
        {
            //Validate Model

            var result = await _customerService.CreateCustomer(request);

            return result;
        }

        [HttpGet(Name = "GetCustomerProfile")]
        public async Task<ApiResponse> GetCustomerProfile(string email)
        {
            //Validate Model

            var result = await _customerService.GetCustomerInfo(email);

            return result;
        }

    }
}
