using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class CustomerRepository : BaseRepository<Customer, AIRPORTContext>, ICustomerRepository
    {
        public async Task<List<Customer>> GetByAddressAsync(string address, params string[] includeList)
        {
            return await GetAllAsync(ctr => ctr.Address == address, includeList);
        }
   
        public async Task<List<Customer>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(ctr => ctr.Name == name, includeList);
        }

        public async Task<List<Customer>> GetBySurnameAsync(string surname, params string[] includeList)
        {
            return await GetAllAsync(ctr => ctr.Surname == surname, includeList);
        }

        public async Task<Customer> GetByIdAsync(int customerId, params string[] includeList)
        {
            return await GetAsync(ctr => ctr.CustomerID == customerId, includeList);
        }

    }
}
