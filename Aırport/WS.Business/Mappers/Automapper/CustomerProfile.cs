using AutoMapper;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerGetDto>()
                 
                .ForMember(
                dest => dest.Name,
                opt => opt.MapFrom(src => src.Name == null
                                  ? ""
                                  : src.Name.ToUpper()))
                 .ForMember(
                dest => dest.Surname,
                opt => opt.MapFrom(src => src.Surname == null
                                  ? ""
                                  : src.Surname.ToUpper()))
                  .ForMember(
                dest => dest.Address,
                opt => opt.MapFrom(src => src.Address == null
                                  ? ""
                                  : src.Address.ToUpper()))     
                .ReverseMap();

            CreateMap<CustomerPostDto, Customer>();
            CreateMap<CustomerPutDto, Customer>();
        }
    }
}