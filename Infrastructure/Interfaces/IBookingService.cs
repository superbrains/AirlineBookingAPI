using Common.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IBookingService
    {
        Task<string> CreateBooking(BookingVM request);
        Task<TicketVM> GenerateTicket(string bookingReference);
        Task<bool> CancelBooking(string bookingReference);
        Task<List<TicketVM>> ViewTickets(int CustomerId);
    }
}
