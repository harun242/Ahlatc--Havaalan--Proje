using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Flight;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IFlightBs
    {
        Task<ApiResponse<List<FlightGetDto>>> GetRouteAsync(params string[] includeList);
        Task<ApiResponse<List<FlightGetDto>>> GetDepartureCityAsync(string DepartureCity, params string[] includeList);
        Task<ApiResponse<List<FlightGetDto>>> GetLandingCityAsync(string LandingCity, params string[] includeList);
        Task<ApiResponse<FlightGetDto>> GetByIdAsync(int routeId, params string[] includeList);

        Task<ApiResponse<Flight>> InsertAsync(FlightPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(FlightPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
