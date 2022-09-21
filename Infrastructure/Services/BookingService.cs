using Common.DTOs.Request;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class BookingService : IBookingService
    {
        public Task<bool> CancelBooking(string bookingReference)
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateBooking(BookingVM request)
        {
            throw new NotImplementedException();
        }

        public Task<TicketVM> GenerateTicket(string bookingReference)
        {
            throw new NotImplementedException();
        }

        public Task<List<TicketVM>> ViewTickets(int CustomerId)
        {
            throw new NotImplementedException();
        }
    }
}
