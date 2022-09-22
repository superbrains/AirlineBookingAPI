using AutoMapper;
using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Common.Enums;
using Common.Extensions;
using Data.Models;
using Data.Transactions;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;

namespace Infrastructure.Services
{
    public class FlightRouteService : IFlightDestinationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightRouteService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddDestination(FlightDestinationVM request)
        {              
            var route = _mapper.Map<FlightDestinations>(request);

            var result = await _unitOfWork.FlightDestination.Add(route);
            await _unitOfWork.CompleteAsync();

            if (result)
            {
                return new ApiResponse(request);
            }
            else
            {
                throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.GeneralError));
            }
        }

        public async Task<ApiResponse> GetAllDestinations()
        {
            var routes = await _unitOfWork.FlightDestination.All();

            return new ApiResponse(routes);
        }

        public async Task<ApiResponse> RemoveDestination(int Id)
        {
            var routes = await _unitOfWork.FlightDestination.GetById(Id);

            if (routes != null)
            {
                await _unitOfWork.FlightDestination.Delete(Id);

                return new ApiResponse("Destination Deleted");
            }

            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.NotFound));

        }
    }
}
