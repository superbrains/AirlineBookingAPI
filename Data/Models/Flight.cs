using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Flight:Base
    {
        public string FlightNo { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
