using Common.DTOs.Request;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FlightRouteService : IFlightDestinationService
    {
        public Task<FlightDestinationVM> AddDestination(FlightDestinationVM request)
        {
            throw new NotImplementedException();
        }

        public Task<List<FlightDestinationVM>> GetAllDestinations()
        {
            throw new NotImplementedException();
        }

        public Task<FlightDestinationVM> RemoveDestination(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
