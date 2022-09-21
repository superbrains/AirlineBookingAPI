using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IPassengerService
    {
        Task<string> CheckIn(string bookingReference);
        Task<string> Checkout(string bookingReference);

        Task<List<PassengerVM>> ViewTravelHistory(int customerId);
    }
}
