using AutoWrapper.Wrappers;
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
        Task<ApiResponse> AddDestination(FlightDestinationVM request);
        Task<ApiResponse> RemoveDestination(int Id);
        Task<ApiResponse> GetAllDestinations();
    }
}
