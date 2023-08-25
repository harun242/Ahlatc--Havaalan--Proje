using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface ISeatNumberRepository:IBaseRepository<SeatNumber>
    {
        Task<List<SeatNumber>> GetByBoardingCityAsync(string boardingCity, params string[] includeList);
        Task<List<SeatNumber>> GetByLandedCityAsync(string landedCity, params string[] includeList);
        Task<List<SeatNumber>> GetByTicketNumberAsync(int ticketNumber, params string[] includeList);

        Task<SeatNumber> GetByIdAsync(int expeditionId , params string[] includeList);
    }
}
