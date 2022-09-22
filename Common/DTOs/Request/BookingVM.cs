using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class BookingVM
    {
        public int CustomerId { get; set; }
        public int FlightScheduleId { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }       
        public bool IsRounTrip { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<string> Seats { get; set; }
    }
}
