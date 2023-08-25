using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        Task<List<Employee>> GetByNameAsync(string name, params string[] includeList);
        Task<List<Employee>> GetBySurnameAsync(string surname, params string[] includeList);
        Task<List<Employee>> GetByEmailAsync(string email, params string[] includeList);

        Task<Employee> GetByIdAsync(int employeeId , params string[] includeList);

    }
}
