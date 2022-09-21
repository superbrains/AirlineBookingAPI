using Data.Repositories.BookingRepo;
using Data.Repositories.CustomersRepo;
using Data.Repositories.FlightRepo;
using Data.Repositories.FlightDestinationRepo;
using Data.Repositories.FlightScheduleRepo;
using Data.Repositories.PassengerRepo;
using Data.Repositories.UsersRepo;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Transactions
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly Data.DBContext.DBContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }
        public IBookingRepository Booking { get; private set; }
        public ICustomerRepository Customer { get; private set; }
        public IFlightRepository Flight { get; private set; }
        public IFlightDestinationRepository FlightDestination { get; private set; }
        public IFlightScheduleRepository FlightSchedule { get; private set; }
        public IPassengerRepository Passenger { get; private set; }
        public UnitOfWork(Data.DBContext.DBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(context, _logger);
            Passenger = new PassengerRepository(context, _logger);
            Booking = new BookingRepository(context, _logger);
            Customer = new CustomerRepository(context, _logger);
            Flight = new FlightRepository(context, _logger);
            FlightDestination = new FlightDestinationRepository(context, _logger);
            FlightSchedule = new FlightScheduleRepository(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
