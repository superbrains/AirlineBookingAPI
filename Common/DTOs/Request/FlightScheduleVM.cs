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
        public DateTime DepatureDate { get; set; }
        public decimal AmountPerAdult { get; set; }
        public decimal AmountPerChild { get; set; }
        public string ETA { get; set; }
    }
}
