using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IFlightScheduleService
    {
        Task<ApiResponse> AddSchedule(FlightScheduleVM request);
        Task<ApiResponse> UpdateSchedule(FlightScheduleVM request);
        Task<ApiResponse> DeleteSchedule(int Id);
        Task<ApiResponse> GetSchedules();
        Task<ApiResponse> GetSchedules(string departure, string arrival, DateTime depatureDate);        
    }
}
