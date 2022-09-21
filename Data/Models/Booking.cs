using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Booking: Base
    {
        public Customer Customer { get; set; }
        public FlightSchedule ScheduleInfo { get; set; }
        public int NumberOfAdults { get; set; }
        public int NumberOfChildren { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public bool IsValid { get; set; }
        public bool IsCheckedIn { get; set; } = false;
        public bool IsRounTrip { get; set; }
        public DateTime ReturnDate { get; set; }
        public List<Seats> SeatNumbers { get; set; }

    }

    public class Seats : Base
    {
        public string SeatNumber { get; set; }
        public Flight Flight { get; set; }
    }

  }
