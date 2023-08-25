using AutoMapper;
using WS.Model.Dtos.Ticket;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketGetDto>()
                
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
                .ForMember(
                dest => dest.Fee,
                opt => opt.MapFrom(src => src.Fee == null
                                  ? 0
                                  : src.Fee.Value * 1.18m))
                .ReverseMap();

            CreateMap<TicketPostDto, Ticket>();
            CreateMap<TicketPutDto, Ticket>();
        }
    }
}