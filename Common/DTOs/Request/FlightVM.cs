using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class FlightVM
    {
        public int Id { get; set; }
        public string FlightNo { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }
}
