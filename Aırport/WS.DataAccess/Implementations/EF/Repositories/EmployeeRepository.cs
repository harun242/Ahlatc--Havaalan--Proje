using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class EmployeeRepository : BaseRepository<Employee, AIRPORTContext>, IEmployeeRepository
    {
        public async Task<List<Employee>> GetByEmailAsync(string email, params string[] includeList)
        {
            return await GetAllAsync(emp => emp .Email == email, includeList);
        }

        public async Task<List<Employee>> GetByNameAsync(string name, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.Name == name, includeList);
        }

        public async Task<List<Employee>> GetBySurnameAsync(string surname, params string[] includeList)
        {
            return await GetAllAsync(emp => emp.Surname == surname, includeList);
        }

        public async Task<Employee> GetByIdAsync(int employeeId, params string[] includeList)
        {
            return await GetAsync(emp => emp.EmployeeID == employeeId, includeList);
        }
    }
}
