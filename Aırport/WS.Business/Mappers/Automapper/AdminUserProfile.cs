using AutoMapper;
using WS.Model.Dtos.AdminPanelUser;
using WS.Model.Entities;

namespace WS.Business.Mappers.Automapper
{
    public class AdminUserProfile : Profile
    {
        public AdminUserProfile()
        {
            CreateMap<AdminPanelUser, AdminPanelUserDto>();
        }
    }
}

