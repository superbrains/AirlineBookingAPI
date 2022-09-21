using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class PassengerVM
    {
        public DateTime TravelDate { get; set; }
        public string FlightNo { get; set; }
        public string BookingReference { get; set; }
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public bool IsRounTrip { get; set; }
        public DateTime ReturnDate { get; set; }

    }
}
