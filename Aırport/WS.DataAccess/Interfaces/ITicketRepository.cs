using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface ITicketRepository:IBaseRepository<Ticket>
    {
        Task<List<Ticket>> GetByPassengerIDAsync(int passengerID, params string[] includeList);
        Task<List<Ticket>> GetByPassengerNameAsync(string passengerName, params string[] includeList);
        Task<List<Ticket>> GetByPassengerSurnameAsync(string passengerSurname, params string[] includeList);
        Task<List<Ticket>> GetByFeeAsync(decimal min, decimal max, params string[] includeList);

        Task<Ticket> GetByIdAsync(int ticketId , params string[] includeList);
    }
}
