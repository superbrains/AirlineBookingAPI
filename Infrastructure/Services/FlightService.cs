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

namespace Infrastructure.Services
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> AddFlight(FlightVM request)
        {
            var flight = _mapper.Map<Flight>(request);

            var result = await _unitOfWork.Flight.Add(flight);
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


        public async Task<ApiResponse> AddFlightSeats(FlightSeatVM request)
        {
            var flightSeat = _mapper.Map<FlightSeat>(request);

            var result = await _unitOfWork.FlightSeat.Add(flightSeat);
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

        public async Task<ApiResponse> GetFlight(int Id)
        {
            var flight = await _unitOfWork.Flight.GetById(Id);

            var flightVm = _mapper.Map<FlightVM>(flight);

            return new ApiResponse(flightVm);
        }

        public async Task<ApiResponse> RemoveFlight(int Id)
        {
            var flight = await _unitOfWork.Flight.GetById(Id);

            if (flight != null)
            {
                await _unitOfWork.Flight.Delete(Id);

                return new ApiResponse("Flight Deleted");
            }

            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.NotFound));
        }

        public async Task<ApiResponse> SetFlightAvailability(int flightId, bool availability)
        {
            var flight = await _unitOfWork.Flight.GetById(flightId);

            if (flight != null)
            {
                flight.IsAvailable = availability;

                await _unitOfWork.Flight.Update(flight);

                return new ApiResponse("Flight Information Updated");
            }

            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.GeneralError));
        }

        public async Task<ApiResponse> UpdateFlight(FlightVM request)
        {
            var flight = await _unitOfWork.Flight.GetById(request.Id);

            if (flight != null)
            {
                var flightData = _mapper.Map<Flight>(request);

                await _unitOfWork.Flight.Update(flightData);

                return new ApiResponse("Flight Information Updated");
            }
            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.GeneralError));
        }
    }
}
