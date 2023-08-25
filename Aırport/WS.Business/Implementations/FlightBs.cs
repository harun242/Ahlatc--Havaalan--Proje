using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using WS.Business.CustomExceptions;
using WS.Business.Interfaces;
using WS.DataAccess.Interfaces;
using WS.Model.Dtos.Flight;
using WS.Model.Entities;

namespace WS.Business.Implementations
{
    public class FlightBs : IFlightBs
    {
        private readonly IFlightRepository _repo;
        private readonly IMapper _mapper;

        public FlightBs(IFlightRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }



        public async Task<ApiResponse<FlightGetDto>> GetByIdAsync(int routeId, params string[] includeList)
        {
            if (routeId <= 0)
                throw new BadRequestException("id değeri 0 dan büyük bir değer olmalıdır");

            var route = await _repo.GetByIdAsync(routeId, includeList);

            if (route == null)
                throw new NotFoundException("bu id li ürün bulunamadı");

            var dto = _mapper.Map<FlightGetDto>(route);

            return ApiResponse<FlightGetDto>.Success(StatusCodes.Status200OK, dto);
        }
        public async Task<ApiResponse<List<FlightGetDto>>> GetDepartureCityAsync(string DepartureCity, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<FlightGetDto>>> GetLandingCityAsync(string LandingCity, params string[] includeList)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponse<List<FlightGetDto>>> GetRouteAsync(params string[] includeList)
        {
            // IsActive eklemesi
            var routes = await _repo.GetAllAsync(p => p.IsActive == true, includeList: includeList);

            if (routes.Count > 0)
            {
                var returnList = _mapper.Map<List<FlightGetDto>>(routes);

                return ApiResponse<List<FlightGetDto>>.Success(StatusCodes.Status200OK, returnList);
            }

            throw new NotFoundException("kaynak bulunamadı");
        }

        public async Task<ApiResponse<Flight>> InsertAsync(FlightPostDto dto)
        {
            if (dto.DepartureCity.Length < 2)
                throw new BadRequestException("kalkış şehri adı en az 2 karakterden oluşmalıdır");

            if (dto.LandingCity.Length < 2)
                throw new BadRequestException("iniş şehri adı en az 2 karakterden oluşmalıdır");

            var entity = _mapper.Map<Flight>(dto);

            var insertedRoute = await _repo.InsertAsync(entity);

            return ApiResponse<Flight>.Success(StatusCodes.Status201Created, insertedRoute);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(FlightPutDto dto)
        {
            if (dto.DepartureCity.Length < 2)
                throw new BadRequestException("kalkış şehri adı en az 2 karakterden oluşmalıdır");

            if (dto.LandingCity.Length < 2)
                throw new BadRequestException("iniş şehri adı en az 2 karakterden oluşmalıdır");


            var entity = _mapper.Map<Flight>(dto);

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
