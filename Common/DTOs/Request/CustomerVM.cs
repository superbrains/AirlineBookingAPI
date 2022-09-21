using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DTOs.Request
{
    public class CustomerVM
    {
        public int Id { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        public string? PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
