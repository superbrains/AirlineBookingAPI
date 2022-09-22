using AutoMapper;
using Common.DTOs.Request;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Users, UserVM>().ReverseMap();
            CreateMap<Customer, CustomerVM>().ReverseMap();
            CreateMap<FlightDestinations, FlightDestinationVM>().ReverseMap();
            CreateMap<Flight, FlightVM>().ReverseMap();
            CreateMap<Booking, BookingVM>().ReverseMap();
            CreateMap<Passenger, PassengerVM>().ReverseMap();
            CreateMap<FlightSchedule, FlightScheduleVM>().ForMember(d=>d.FlightId, opt=> opt.MapFrom(src=>src.Flight.Id)).ReverseMap();
        }
    }
}
