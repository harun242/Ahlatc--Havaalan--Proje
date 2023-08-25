using AutoMapper;
using WS.Model.Dtos.Flight;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class FlightProfile : Profile
    {
        public FlightProfile()
        {
            CreateMap<Flight, FlightGetDto>() 
                .ForMember(
                dest => dest.DepartureCity,
                opt => opt.MapFrom(src => src.DepartureCity == null
                                  ? ""
                                  : src.DepartureCity.ToUpper()))
               .ForMember(
                dest => dest.LandingCity,
                opt => opt.MapFrom(src => src.LandingCity == null
                                  ? ""
                                  : src.LandingCity.ToUpper()))
                .ReverseMap();

            CreateMap<FlightPostDto, Flight>();
            CreateMap<FlightPutDto, Flight>();
        }
    }
}