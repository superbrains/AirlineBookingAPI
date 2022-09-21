using Common.DTOs.Request;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class PassengerService : IPassengerService
    {
        public Task<string> CheckIn(string bookingReference)
        {
            throw new NotImplementedException();
        }

        public Task<string> Checkout(string bookingReference)
        {
            throw new NotImplementedException();
        }

        public Task<List<PassengerVM>> ViewTravelHistory(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
