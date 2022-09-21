using Common.DTOs.Request;
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
        public Task<FlightScheduleVM> AddSchedule(FlightScheduleVM request)
        {
            throw new NotImplementedException();
        }

        public Task<FlightScheduleVM> DeleteSchedule(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<FlightScheduleVM>> GetSchedules()
        {
            throw new NotImplementedException();
        }

        public Task<List<FlightScheduleVM>> GetSchedules(string departure, string arrival, DateTime depatureDate)
        {
            throw new NotImplementedException();
        }

        public Task<FlightScheduleVM> UpdateSchedule(FlightScheduleVM request)
        {
            throw new NotImplementedException();
        }
    }
}
