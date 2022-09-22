using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IFlightService
    {
        Task<ApiResponse> AddFlight(FlightVM request);
        Task<ApiResponse> AddFlightSeats(FlightSeatVM request);      
        Task<ApiResponse> UpdateFlight(FlightVM request);
        Task<ApiResponse> RemoveFlight(int Id);
        Task<ApiResponse> GetFlight(int Id);
        Task<ApiResponse> SetFlightAvailability(int flightId, bool availability);
    }
}
