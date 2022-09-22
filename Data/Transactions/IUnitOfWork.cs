using Data.Repositories.BookingRepo;
using Data.Repositories.CustomersRepo;
using Data.Repositories.FlightRepo;
using Data.Repositories.FlightDestinationRepo;
using Data.Repositories.FlightScheduleRepo;
using Data.Repositories.PassengerRepo;
using Data.Repositories.UsersRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Repositories.TicketRepo;
using Data.Repositories.FlightSeatRepo;

namespace Data.Transactions
{
    public interface IUnitOfWork
    {
        IUserRepository Users { get; }
        IBookingRepository Booking { get; }
        ICustomerRepository Customer { get; }
        IFlightRepository Flight { get; }
        IFlightDestinationRepository FlightDestination { get; }
        IFlightScheduleRepository FlightSchedule { get; }
        IPassengerRepository Passenger { get; }
        ITicketRepository Ticket { get; }
        IFlightSeatRepository FlightSeat { get; }
        Task CompleteAsync();
    }
}
