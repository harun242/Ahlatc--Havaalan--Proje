using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.AdminPanelUser;

namespace WS.Business.Interfaces
{
    public interface IAdminPanelUserBs
    {
        Task<ApiResponse<AdminPanelUserDto>> LogInAsync(string userName, string password, params string[] includeList);
    }
}
