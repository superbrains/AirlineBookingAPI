using AutoMapper;
using AutoWrapper.Wrappers;
using Common.DTOs.Request;
using Common.Enums;
using Common.Extensions;
using Data.Models;
using Data.Transactions;
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BookingService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ApiResponse> CancelBooking(string bookingref)
        {
            var ticket = await _unitOfWork.Ticket.FindOne(x => x.BookingReference == bookingref);
            if(ticket != null)
            {
                var booking = await _unitOfWork.Booking.FindOne(x => x.Id == ticket.BookingID);
              
                await _unitOfWork.Ticket.Delete(ticket.Id);
                await _unitOfWork.Booking.Delete(booking.Id);

                await _unitOfWork.CompleteAsync();

                ///Call Money Refund.....based on Policy
               

                return new ApiResponse("Booking has been cancelled");
                }

            throw new ApiException("Error Occured while cancelling your booking");
        }

        public async Task<ApiResponse> CreateBooking(BookingVM request)
        {
            //ChecK the booking Info against the Schedule to confirm prices and Other Validations as required
            var schedule = await _unitOfWork.FlightSchedule.FindOne(x=>x.Id==request.FlightScheduleId);
            if (schedule == null)
            {
                throw new ApiException("No Flight Schedule corresponds with your submission");
            }

            var expectedFee = (schedule.AmountPerAdult * request.NumberOfAdults) + (schedule.AmountPerChild * request.NumberOfChildren);

            if(expectedFee< request.TotalAmount)
            {
                throw new ApiException("Kindly make a complete payment to proceed with flight booking");
            }

            //Create Booking if every details is correct
           
            List<Seats> seats = new List<Seats>();
            foreach (var item in request.Seats)
            {
                seats.Add(new Seats { SeatNumber = item, Flight = schedule.Flight });
            }
            var booking = _mapper.Map<Booking>(request);
            booking.SeatNumbers = seats;
            booking.IsValid = true;
            booking.IsCheckedIn = false;

            await _unitOfWork.Booking.Add(booking);

            //Generate and Store Ticket
            var bookingRef = Guid.NewGuid().ToString().Substring(1, 5).ToUpper();
            Ticket ticket = new Ticket();
            ticket.BookingReference = bookingRef;
            ticket.BookingID = booking.Id;
            ticket.FlightScheduleID = schedule.Id;
            await _unitOfWork.Ticket.Add(ticket);

            await _unitOfWork.CompleteAsync();

            //Return TicketVM Instead
            return new ApiResponse(ticket);
         
        }

        public async Task<ApiResponse> GetAvailableFlightSeats(int flightId)
        {
            var flightSeats = await _unitOfWork.FlightSeat.FindAll(x => x.Flight.Id == flightId);

            var booking = await _unitOfWork.Booking.FindAll(x => x.ScheduleInfo.Flight.Id==flightId);

            var bookedSeats = booking.Select(x => x.SeatNumbers).ToList();
            

            foreach (var curPosition in flightSeats)
            {
                foreach (var bookedseats in bookedSeats)
                {
                    foreach (var seat in bookedseats)
                    {
                        if (curPosition.SeatNo == seat.SeatNumber)
                        {
                            flightSeats.ToList().Remove(curPosition);
                        }
                    }
                }
            }


            return new ApiResponse(flightSeats);
        }

        public Task<ApiResponse> ViewTickets(int CustomerId)
        {
            throw new NotImplementedException();
        }
    }
}
