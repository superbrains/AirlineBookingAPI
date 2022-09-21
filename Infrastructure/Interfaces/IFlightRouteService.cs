using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IFlightDestinationService
    {
        Task<FlightDestinationVM> AddDestination(FlightDestinationVM request);
        Task<FlightDestinationVM> RemoveDestination(int Id);
        Task<List<FlightDestinationVM>> GetAllDestinations();
    }
}
