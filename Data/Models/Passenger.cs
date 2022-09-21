using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Passenger:Base
    {
        public Booking BookingInfo { get; set; }
        public DateTime TimeCheckedIn { get; set; }
        public Users CheckedInBy { get; set; }
        public bool HasArrived { get; set; } = false;
        public DateTime ArrivalTime { get; set; }
    }
}
