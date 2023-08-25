using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.SeatNumber;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class SeatNumberBs : ISeatNumberBs
    {
        private readonly ISeatNumberRepository _repo;
        private readonly IMapper _mapper;

        public SeatNumberBs(ISeatNumberRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

       
        public async Task<ApiResponse<List<SeatNumberGetDto>>> GetBoardingCityAsync(string boardingCity, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<SeatNumberGetDto>> GetByIdAsync(int expeditionId, params string[] includeList)
        {
            if (expeditionId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var seatNumber = await _repo.GetByIdAsync(expeditionId, includeList);

            if (seatNumber == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<SeatNumberGetDto>(seatNumber);

            return ApiResponse<SeatNumberGetDto>.Success(StatusCodes.Status200OK, dto);
        }

        public async Task<ApiResponse<List<SeatNumberGetDto>>> GetLandedCityAsync(string landedCity, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<SeatNumberGetDto>>> GetSeatNumberAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var seatNumbers = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (seatNumbers.Count > 0)
            {
                var returnList = _mapper.Map<List<SeatNumberGetDto>>(seatNumbers);

                return ApiResponse<List<SeatNumberGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<List<SeatNumberGetDto>>> GetTicketNumberAsync(int ticketNumber, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<SeatNumber>> InsertAsync(SeatNumberPostDto dto)
        {
            if (dto.BoardingCity.Length < 2)
                throw new BadRequestException("biniş şehri  adı en az 2 karakterden oluşmalıdır");

            if (dto.LandedCity.Length < 2)
                throw new BadRequestException("iniş şehri adı en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<SeatNumber>(dto);

            var insertedSeatNumber = await _repo.InsertAsync(entity);

            return ApiResponse<SeatNumber>.Success(StatusCodes.Status201Created, insertedSeatNumber);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(SeatNumberPutDto dto)
        {
            if (dto.BoardingCity.Length < 2)
                throw new BadRequestException("biniş şehri  adı en az 2 karakterden oluşmalıdır");

            if (dto.LandedCity.Length < 2)
                throw new BadRequestException("iniş şehri adı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<SeatNumber>(dto);

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
