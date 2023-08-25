using AutoMapper;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeGetDto>()
                 
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
                dest => dest.Email,
                opt => opt.MapFrom(src => src.Email == null
                                  ? ""
                                  : src.Email.ToUpper()))
                .ReverseMap();

            CreateMap<EmployeePostDto, Employee>();
            CreateMap<EmployeePutDto, Employee>();
        }
    }
}