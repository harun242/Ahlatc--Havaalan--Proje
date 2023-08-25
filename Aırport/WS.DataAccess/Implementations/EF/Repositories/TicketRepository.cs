using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class TicketRepository : BaseRepository<Ticket, AIRPORTContext>, ITicketRepository
    {
        public async Task<List<Ticket>> GetByFeeAsync(decimal min, decimal max, params string[] includeList)
        {
            return await GetAllAsync(tkt => tkt.Fee > min && tkt.Fee < max, includeList);
        }

        public async Task<List<Ticket>> GetByPassengerIDAsync(int passengerID, params string[] includeList)
        {
            return await GetAllAsync(tkt => tkt.PassengerID == passengerID, includeList);
        }
  
        public async Task<List<Ticket>> GetByPassengerNameAsync(string passengerName, params string[] includeList)
        {
            return await GetAllAsync(tkt => tkt.PassengerName == passengerName, includeList);
        }

        public async Task<List<Ticket>> GetByPassengerSurnameAsync(string passengerSurname, params string[] includeList)
        {
            return await GetAllAsync(tkt => tkt.PassengerSurname == passengerSurname, includeList);
        }

        public async Task<Ticket> GetByIdAsync(int ticketId, params string[] includeList)
        {
            return await GetAsync(tkt => tkt.TıcketID == ticketId, includeList);
        }
    }
}
