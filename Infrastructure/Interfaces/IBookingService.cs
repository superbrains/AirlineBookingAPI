using AutoWrapper.Wrappers;
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
        Task<ApiResponse> CreateBooking(BookingVM request);
        Task<ApiResponse> CancelBooking(string bookingref);
        Task<ApiResponse> GetAvailableFlightSeats(int flightId);
        Task<ApiResponse> ViewTickets(int CustomerId);
      
    }
}
