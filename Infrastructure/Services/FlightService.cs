using Common.DTOs.Request;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FlightService : IFlightService
    {
        public Task<FlightVM> AddFlight(FlightVM request)
        {
            throw new NotImplementedException();
        }

        public Task<FlightVM> GetFlight(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightVM> RemoveFlight(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<FlightVM> SetFlightAvailability(int flightId, bool availability)
        {
            throw new NotImplementedException();
        }

        public Task<FlightVM> UpdateFlight(FlightVM request)
        {
            throw new NotImplementedException();
        }
    }
}
