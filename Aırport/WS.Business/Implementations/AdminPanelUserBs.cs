﻿using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.AdminPanelUser;

namespace WS.Business.Implementations
{
    public class AdminPanelUserBs : IAdminPanelUserBs
    {
        private readonly IAdminPanelUserRepository _adminPanelUserRepository;
        private readonly IMapper _mapper;

        public AdminPanelUserBs(IAdminPanelUserRepository adminPanelUserRepository, IMapper mapper)
        {
            _adminPanelUserRepository = adminPanelUserRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<AdminPanelUserDto>> LogInAsync(string userName, string password, params string[] includeList)
        {
            if (string.IsNullOrEmpty(userName))
            {
                throw new BadRequestException("Kullanıcı adı boş bırakılamaz");
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new BadRequestException("Şifre boş bırakılamaz");
            }

            if (userName.Length <= 2)
            {
                throw new BadRequestException("Kullanıcı adı en az 2 karakter olmalıdır");
            }

            var adminUser = await _adminPanelUserRepository.GetByUserNameAndPasswordAsync(userName, password, includeList);

            if (adminUser == null)
            {
                throw new BadRequestException("Kullanıcı Bulunamadı");
            }
            var list = _mapper.Map<AdminPanelUserDto>(adminUser);

            return ApiResponse<AdminPanelUserDto>.Success(StatusCodes.Status200OK, list);
        }
    }
}

