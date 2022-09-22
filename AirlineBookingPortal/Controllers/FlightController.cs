using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly ILogger<FlightController> _logger;
        private readonly IFlightDestinationService _flightDestinationService;
        private readonly IFlightService _flightService;
        private readonly IFlightScheduleService _flightScheduleService;
        public FlightController(ILogger<FlightController> logger, IFlightDestinationService flightDestinationService, IFlightService flightService, IFlightScheduleService flightScheduleService)
        {
            _logger = logger;
            _flightDestinationService = flightDestinationService;
            _flightService = flightService;
            _flightScheduleService = flightScheduleService;
        }

       
        [HttpPost(Name = "AddFlightSeats")]
        [Route("AddFlightSeats")]
        public async Task<ApiResponse> AddFlightSeats(FlightSeatVM request)
        {
            //Validate Model
            var result = await _flightService.AddFlightSeats(request);

            return result;
        }

        [HttpPost(Name = "UpdateFlight")]
        [Route("UpdateFlight")]
        public async Task<ApiResponse> UpdateFlight(FlightVM request)
        {
            //Validate Model
            var result = await _flightService.UpdateFlight(request);

            return result;
        }

      
        [HttpPost(Name = "RemoveFlight")]
        [Route("RemoveFlight")]
        public async Task<ApiResponse> RemoveFlight(int flightId)
        {
            //Validate Model
            var result = await _flightService.RemoveFlight(flightId);

            return result;
        }

        [HttpGet(Name = "GetFlight")]
        [Route("GetFlight")]
        public async Task<ApiResponse> GetFlight(int flightId)
        {
            //Validate Model
            var result = await _flightService.GetFlight(flightId);

            return result;
        }

       

        [HttpPost(Name = "SetFlightAvailability")]
        [Route("SetFlightAvailability")]
        public async Task<ApiResponse> SetFlightAvailability(int flightId, bool availability)
        {
            //Validate Model
            var result = await _flightService.SetFlightAvailability( flightId,  availability);

            return result;
        }

        [HttpPost(Name = "AddFlightDestination")]
        [Route("AddFlightDestination")]
        public async Task<ApiResponse> AddFlightDestination(FlightDestinationVM request)
        {
            //Validate Model

            var result = await _flightDestinationService.AddDestination(request);

            return result;
        }

        [HttpPost(Name = "RemoveDestination")]
        [Route("RemoveDestination")]
        public async Task<ApiResponse> RemoveDestination(int destinationId)
        {
            //Validate Model

            var result = await _flightDestinationService.RemoveDestination(destinationId);

            return result;
        }

        [HttpGet(Name = "GetAllDestinations")]
        [Route("GetAllDestinations")]
        public async Task<ApiResponse> GetAllDestinations()
        {
            //Validate Model

            var result = await _flightDestinationService.GetAllDestinations();

            return result;
        }


    }
}
