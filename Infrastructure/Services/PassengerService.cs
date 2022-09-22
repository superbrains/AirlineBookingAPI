using AutoMapper;
using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Data.Transactions;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PassengerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CheckIn(string bookingReference)
        {
            var ticket = await _unitOfWork.Ticket.FindOne(x => x.BookingReference == bookingReference);
            if (ticket != null)
            {
                var booking= await _unitOfWork.Booking.GetById(ticket.BookingID);
                booking.IsCheckedIn = true;

                await _unitOfWork.Booking.Update(booking);

                await _unitOfWork.CompleteAsync();

                return new ApiResponse("Checked In");
            }

            throw new ApiException("Error Checking In");
        }

        public Task<ApiResponse> Checkout(string bookingReference)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse> ViewTicketInfo(string bookingReference)
        {
            var ticket = await _unitOfWork.Ticket.FindOne(x => x.BookingReference == bookingReference);
            if (ticket == null)
            {
                throw new ApiException("Ticket Not Found");
            }

            return new ApiResponse(ticket);
        }

        public async Task<ApiResponse> ViewTravelHistory(int customerId)
        {
            var booking = await _unitOfWork.Booking.FindAll(x=>x.Customer.Id ==customerId && x.IsCheckedIn);

            if(booking == null)
            {
                return new ApiResponse(booking);
            }

            throw new ApiException("No Booking Found");
        }
    }
}
