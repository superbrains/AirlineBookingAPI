using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class FlightScheduleVM
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string DepartingFrom { get; set; }
        public string ArrivingAt { get; set; }
        public DateTime DepatureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }

        public decimal AmountPerAdult { get; set; }
        public decimal AmountPerChild { get; set; }
     
    }
}
