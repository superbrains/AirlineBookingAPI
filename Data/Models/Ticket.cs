﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Ticket : Base
    {
        public string BookingReference { get; set; }
        public FlightSchedule FlightInfo { get; set; }
        public Booking BookingInfo { get; set; }
    }
}
