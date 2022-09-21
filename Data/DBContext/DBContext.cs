using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DBContext
{
    public class DBContext : DbContext
    {
        // The DbSet property will tell EF Core tha we have a table that needs to be created
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightDestinations> FlightDestinations { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Seats> Seats { get; set; }
        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        // On model creating function will provide us with the ability to manage the tables properties
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Booking>()
        .Property(p => p.TotalAmount)
        .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Booking>()
       .Property(p => p.AmountPaid)
       .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<FlightSchedule>()
      .Property(p => p.AmountPerAdult)
      .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<FlightSchedule>()
    .Property(p => p.AmountPerChild)
    .HasColumnType("decimal(18,4)");
        }
    }
}
