using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Employee;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IEmployeeBs
    {
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmployeeAsync(params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetSurnameAsync(string surname, params string[] includeList);
        Task<ApiResponse<List<EmployeeGetDto>>> GetEmailAsync(string email, params string[] includeList);

        Task<ApiResponse<EmployeeGetDto>> GetByIdAsync(int employeeId, params string[] includeList);

        Task<ApiResponse<Employee>> InsertAsync(EmployeePostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(EmployeePutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
