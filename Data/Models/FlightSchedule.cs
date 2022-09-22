using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class FlightSchedule : Base
    {
        public Flight Flight { get; set; }
        public string DepartingFrom { get; set; }
        public string ArrivingAt { get; set; }
        public DateTime DepatureDateTime { get; set; }
        public DateTime ArrivalDateTime { get; set; }
        public decimal AmountPerAdult { get; set; }
        public decimal AmountPerChild { get; set; }
        public string ETA { get; set; }
    }
}
