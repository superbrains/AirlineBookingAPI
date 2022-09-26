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
    [RequiredScope("tasks.read")]
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]/[action]")]
    public class BookingController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly IBookingService _bookingService;
        private readonly IPassengerService _passengerService;
       
        public BookingController(ILogger<FlightController> logger, IBookingService bookingService, IPassengerService passengerService)
        {
            _logger = logger;
            _bookingService = bookingService;
            _passengerService = passengerService;           
        }


        [Microsoft.AspNetCore.Mvc.HttpGet(Name = "GetAvailableFlightSeats")]
        public async Task<ApiResponse> GetAvailableFlightSeats(int flightId)
        {
            //Validate Model
            var result = await _bookingService.GetAvailableFlightSeats(flightId);

            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "CreateBooking")]
        public async Task<ApiResponse> CreateBooking(BookingVM request)
        {
            //Validate Model
            var result = await _bookingService.CreateBooking(request);

            return result;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "CheckIn")]
        public async Task<ApiResponse> CheckIn(string bookingReference)
        {
            //Validate Model
            var result = await _passengerService.CheckIn(bookingReference);

            return result;
        }


        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "CheckOut")]
        public async Task<ApiResponse> CheckOut(string bookingReference)
        {
            //Validate Model
            var result = await _passengerService.Checkout(bookingReference);

            return result;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost(Name = "ViewTravelHistory")]
        public async Task<ApiResponse> ViewTravelHistory(int customerId)
        {
            //Validate Model
            var result = await _passengerService.ViewTravelHistory(customerId);

            return result;
        }
    }
}
