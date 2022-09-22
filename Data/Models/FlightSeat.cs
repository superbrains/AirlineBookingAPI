using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class FlightSeat: Base
    {
        public Flight Flight { get; set; }
        public string SeatNo { get; set; }
    }
}
