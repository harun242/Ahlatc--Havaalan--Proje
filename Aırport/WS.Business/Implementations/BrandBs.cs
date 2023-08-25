using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Brand;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class BrandBs : IBrandBs
    {
        private readonly IBrandRepository _repo;
        private readonly IMapper _mapper;

        public BrandBs(IBrandRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       

        public async Task<ApiResponse<List<BrandGetDto>>> GetBrandAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var brands = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (brands.Count > 0)
            {
                var returnList = _mapper.Map<List<BrandGetDto>>(brands);

                return ApiResponse<List<BrandGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<BrandGetDto>>> GetByBrandNameAsync(string brandname, params string[] includeList)
        {
            throw new NotImplementedException();

        }

        public async Task<ApiResponse<BrandGetDto>> GetByIdAsync(int brandId, params string[] includeList)
        {
            if (brandId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var Brand = await _repo.GetByIdAsync(brandId, includeList);

            if (Brand == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<BrandGetDto>(Brand);

            return ApiResponse<BrandGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<Brand>> InsertAsync(BrandPostDto dto)
        {
            if (dto.BrandName.Length < 2)
                throw new BadRequestException("Marka adı en az 2 karakterden oluşmalıdır");
         
            var entity = _mapper.Map<Brand>(dto);

            var insertedbrand = await _repo.InsertAsync(entity);

            return ApiResponse<Brand>.Success(StatusCodes.Status201Created, insertedbrand);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(BrandPutDto dto)
        {
            if (dto.BrandID <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");

            if (dto.BrandName.Length < 2)
                throw new BadRequestException("Marka adı en az 2 karakterden oluşmalıdır");  

            var entity = _mapper.Map<Brand>(dto);
        
            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
        public async Task<ApiResponse<NoData>> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new BadRequestException("id pozitif bir değer olmalıdır");

            var entity = await _repo.GetByIdAsync(id);

            // IsActive False döndürme
            entity.IsActive = false;

            await _repo.UpdateAsync(entity);

            return ApiResponse<NoData>.Success(StatusCodes.Status200OK);
        }
    }
}
