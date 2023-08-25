using AutoMapper;
using WS.Model.Dtos.Brand;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class BrandProfile : Profile

    {
        public BrandProfile()
        {

            CreateMap<Brand,  BrandGetDto>()
                 
                 .ForMember(
                     dest => dest.BrandName,
                     opt => opt.MapFrom(src => src.BrandName == null 
                                   ? "" 
                                   : src.BrandName))


                 .ReverseMap();

            CreateMap<BrandPostDto, Brand>();
            CreateMap<BrandPutDto, Brand>();

        }
    }
}