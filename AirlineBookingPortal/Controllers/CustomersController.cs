using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using System.Web.Http;

namespace AirlineBookingAPI.Controllers
{
    [Authorize]
    [RequiredScope("api.users")]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    public class CustomersController : ControllerBase
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomerService _customerService;
        private readonly IHttpContextAccessor _contextAccessor;
        public CustomersController(IHttpContextAccessor contextAccessor,ILogger<CustomersController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
            _contextAccessor = contextAccessor;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "Register")]
        public async Task<ApiResponse> Register(CustomerVM request)
        {
            //Validate Model

            //To Get the Name, get others...
            //var name = User.Identity?.Name;
           
            var result = await _customerService.CreateCustomer(request);

            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetCustomerProfile")]
        public async Task<ApiResponse> GetCustomerProfile(string email)
        {
            //Validate Model

            var result = await _customerService.GetCustomerInfo(email);

            return result;
        }

    }
}
