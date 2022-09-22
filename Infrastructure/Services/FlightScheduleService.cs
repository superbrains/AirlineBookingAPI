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
    public class FlightScheduleService : IFlightScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public FlightScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ApiResponse> AddSchedule(FlightScheduleVM request)
        {
            //Check for Flight Availability
            var flightExists = await _unitOfWork.Flight.FindOne(x => x.Id == request.FlightId);
            if (flightExists == null)
            {
                throw new ApiException("Flight Does not Exist");
            }

            var flightAvailabilty = await _unitOfWork.Flight.FindOne(x => x.Id == request.FlightId && x.IsAvailable);
            if (flightAvailabilty == null)
            {
                throw new ApiException("Flight is not available for Scheduling");
            }

            //Check for Scheduling Conflicts
            var scheduleConflicts = await _unitOfWork.FlightSchedule.FindAll(x => x.Flight.Id == request.FlightId && x.DepatureDateTime>= request.DepatureDateTime && x.ArrivalDateTime<=request.ArrivalDateTime);
            if (scheduleConflicts.ToList().Count > 0)
            {
                throw new ApiException("Conflicts Detected in Flight Schedule");
            }


            var schedule = _mapper.Map<FlightSchedule>(request);

            var result = await _unitOfWork.FlightSchedule.Add(schedule);
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

        public async Task<ApiResponse> DeleteSchedule(int Id)
        {
            var schedule = await _unitOfWork.FlightSchedule.GetById(Id);

            if (schedule != null)
            {
                await _unitOfWork.FlightSchedule.Delete(Id);

                return new ApiResponse("Flight Schedule Deleted");
            }

            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.NotFound));
        }

        public async Task<ApiResponse> GetSchedules()
        {
            var flight = await _unitOfWork.FlightSchedule.All();

            var flightVm = _mapper.Map<FlightVM>(flight);

            return new ApiResponse(flightVm);
        }

        public async Task<ApiResponse> GetSchedules(string departure, string arrival, DateTime depatureDate)
        {
            var flight = await _unitOfWork.FlightSchedule.FindAll(x=>x.DepartingFrom== departure && x.ArrivingAt==arrival && (x.DepatureDateTime.Year==depatureDate.Year && x.DepatureDateTime.Month==depatureDate.Month && x.DepatureDateTime.Day==depatureDate.Day));

            var flightVm = _mapper.Map<FlightVM>(flight);

            return new ApiResponse(flightVm);
        }

        public async Task<ApiResponse> UpdateSchedule(FlightScheduleVM request)
        {
            var schedule = await _unitOfWork.FlightSchedule.GetById(request.Id);

            if (schedule != null)
            {
                var flightSchedule = _mapper.Map<FlightSchedule>(request);

                await _unitOfWork.FlightSchedule.Update(flightSchedule);

                return new ApiResponse("Flight Schedule Updated");
            }
            throw new ApiException(ExtentionClass.GetStatusMessage(StatusCode.GeneralError));
        }
    }
}
