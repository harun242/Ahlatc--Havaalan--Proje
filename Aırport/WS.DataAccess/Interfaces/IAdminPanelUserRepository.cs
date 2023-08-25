using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface IAdminPanelUserRepository : IBaseRepository<AdminPanelUser>
    {
        Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList);
    }
}
