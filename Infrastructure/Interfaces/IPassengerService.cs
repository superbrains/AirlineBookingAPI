using AutoWrapper.Wrappers;
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
        Task<ApiResponse> CheckIn(string bookingReference);
        Task<ApiResponse> Checkout(string bookingReference);
        Task<ApiResponse> ViewTicketInfo(string bookingReference);

        Task<ApiResponse> ViewTravelHistory(int customerId);
    }
}
