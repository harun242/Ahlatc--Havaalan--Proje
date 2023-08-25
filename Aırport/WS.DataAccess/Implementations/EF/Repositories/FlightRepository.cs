using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class FlightRepository : BaseRepository<Flight, AIRPORTContext>, IFlightRepository
    {
        public async Task<List<Flight>> GetAllDepartureCityAsync(string DepartureCity, params string[] includeList)
        {
            return await GetAllAsync(rte => rte.DepartureCity == DepartureCity, includeList);
        }

        public async Task<List<Flight>> GetAllLandingCityAsync(string LandingCity, params string[] includeList)
        {
            return await GetAllAsync(rte => rte.LandingCity == LandingCity, includeList);
        }

        public async Task<Flight> GetByIdAsync(int routeId, params string[] includeList)
        {
            return await GetAsync(rte => rte.RouteID == routeId, includeList);
        }
    }
}
