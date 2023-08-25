using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Ticket;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface ITicketBs
    {

        Task<ApiResponse<List<TicketGetDto>>> GetTicketAsync(params string[] includeList);
        Task<ApiResponse<List<TicketGetDto>>> GetPassengerNameAsync(string passengerName, params string[] includeList);
        Task<ApiResponse<List<TicketGetDto>>> GetPassengerSurnameAsync(string passengerSurname, params string[] includeList);
        Task<ApiResponse<List<TicketGetDto>>> GetFeeAsync(decimal min, decimal max, params string[] includeList);

        Task<ApiResponse<TicketGetDto>> GetByIdAsync(int ticketId, params string[] includeList);

        Task<ApiResponse<Ticket>> InsertAsync(TicketPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(TicketPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
