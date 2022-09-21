using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class TicketVM
    {
        public string BookingReference { get; set; }
        public FlightScheduleVM FlightInfo { get; set; }
        public BookingVM BookingInfo { get; set; }
    }
}
