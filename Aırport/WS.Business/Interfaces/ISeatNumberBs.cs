using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.SeatNumber;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ISeatNumberBs
    {

        Task<ApiResponse<List<SeatNumberGetDto>>> GetSeatNumberAsync(params string[] includeList);
        Task<ApiResponse<List<SeatNumberGetDto>>> GetBoardingCityAsync(string boardingCity, params string[] includeList);
        Task<ApiResponse<List<SeatNumberGetDto>>> GetLandedCityAsync(string landedCity, params string[] includeList);
        Task<ApiResponse<List<SeatNumberGetDto>>> GetTicketNumberAsync(int ticketNumber, params string[] includeList);

        Task<ApiResponse<SeatNumberGetDto>> GetByIdAsync(int expeditionId, params string[] includeList);

        Task<ApiResponse<SeatNumber>> InsertAsync(SeatNumberPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(SeatNumberPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
