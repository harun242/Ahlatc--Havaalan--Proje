using AutoMapper;
using WS.Model.Dtos.SeatNumber;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class SeatNumberProfile : Profile
    {
        public SeatNumberProfile()
        {
            CreateMap<SeatNumber, SeatNumberGetDto>()
                
                .ForMember(
                dest => dest.LandedCity,
                opt => opt.MapFrom(src => src.LandedCity == null
                                  ? ""
                                  : src.LandedCity.ToUpper()))
                .ForMember(
                dest => dest.BoardingCity,
                opt => opt.MapFrom(src => src.BoardingCity == null
                                  ? ""
                                  : src.BoardingCity.ToUpper())) 
                .ReverseMap();

            CreateMap<SeatNumberPostDto, SeatNumber>();
            CreateMap<SeatNumberPutDto, SeatNumber>();
        }
    }
}