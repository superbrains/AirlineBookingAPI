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
        Task<FlightScheduleVM> AddSchedule(FlightScheduleVM request);
        Task<FlightScheduleVM> UpdateSchedule(FlightScheduleVM request);
        Task<FlightScheduleVM> DeleteSchedule(int Id);
        Task<List<FlightScheduleVM>> GetSchedules();
        Task<List<FlightScheduleVM>> GetSchedules(string departure, string arrival, DateTime depatureDate);
        
    }
}
