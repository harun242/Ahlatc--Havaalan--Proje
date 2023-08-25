using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ICustomerBs
    {

        Task<ApiResponse<List<CustomerGetDto>>> GetCustomerAsync(params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetNameAsync(string name, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetSurnameAsync(string surname, params string[] includeList);
        Task<ApiResponse<List<CustomerGetDto>>> GetAddressAsync(string address, params string[] includeList);
        Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int customerId, params string[] includeList);

        Task<ApiResponse<Customer>> InsertAsync(CustomerPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(CustomerPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
