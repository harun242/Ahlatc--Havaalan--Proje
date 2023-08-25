using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class AdminPanelUserRepository : BaseRepository<AdminPanelUser, AIRPORTContext>, IAdminPanelUserRepository
    {
        public async Task<AdminPanelUser> GetByUserNameAndPasswordAsync(string userName, string password, params string[] includeList)
        {
            return await GetAsync(x => x.UserName == userName && x.Password == password && x.IsActive.Value, includeList);
        }
    }
}
