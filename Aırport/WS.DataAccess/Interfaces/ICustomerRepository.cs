using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface ICustomerRepository:IBaseRepository<Customer>
    {
        Task<List<Customer>> GetByNameAsync(string name, params string[] includeList);
        Task<List<Customer>> GetBySurnameAsync(string surname, params string[] includeList);
        Task<List<Customer>> GetByAddressAsync(string address, params string[] includeList);

        Task<Customer> GetByIdAsync(int customerId , params string[] includeList);
    }
}
