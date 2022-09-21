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
        Task<FlightVM> AddFlight(FlightVM request);
        Task<FlightVM> UpdateFlight(FlightVM request);
        Task<FlightVM> RemoveFlight(int Id);
        Task<FlightVM> GetFlight(int Id);
        Task<FlightVM> SetFlightAvailability(int flightId, bool availability);
    }
}
