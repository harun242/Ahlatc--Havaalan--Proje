using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface IFlightRepository:IBaseRepository<Flight>
    {
        Task<List<Flight>> GetAllDepartureCityAsync(string DepartureCity, params string[] includeList);
        Task<List<Flight>> GetAllLandingCityAsync(string LandingCity, params string[] includeList);

        Task<Flight> GetByIdAsync(int routeId , params string[] includeList);
    }
}
