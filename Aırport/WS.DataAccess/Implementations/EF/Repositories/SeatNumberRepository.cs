using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class SeatNumberRepository : BaseRepository<SeatNumber, AIRPORTContext>, ISeatNumberRepository
    {
        public async Task<List<SeatNumber>> GetByBoardingCityAsync(string boardingCity, params string[] includeList)
        {
            return await GetAllAsync(stnm => stnm.BoardingCity == boardingCity, includeList);
        }

        public async Task<List<SeatNumber>> GetByLandedCityAsync(string landedCity, params string[] includeList)
        {
            return await GetAllAsync(stnm => stnm.LandedCity == landedCity, includeList);
        }

        public async Task<List<SeatNumber>> GetByTicketNumberAsync(int ticketNumber, params string[] includeList)
        {
            return await GetAllAsync(stnm => stnm.TicketNumber == ticketNumber, includeList);
        }

        public async Task<SeatNumber> GetByIdAsync(int expeditionId, params string[] includeList)
        {
            return await GetAsync(stnm => stnm.ExpeditionID == expeditionId, includeList);
        }
    }
}
