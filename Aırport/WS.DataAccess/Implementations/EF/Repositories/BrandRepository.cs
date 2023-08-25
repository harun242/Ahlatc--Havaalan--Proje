using Infrastructure.DataAccess.EF;
using WS.DataAccess.Implementations.EF.Contexts;
using WS.DataAccess.Interfaces;
using WS.Model.Entities;

namespace WS.DataAccess.Implementations.EF.Repositories
{
    public class BrandRepository : BaseRepository<Brand, AIRPORTContext>, IBrandRepository
    {
        public async Task<List<Brand>> GetByBrandNameAsync(string brandname, params string[] includeList)
        {
            return await GetAllAsync(brd => brd.BrandName == brandname, includeList);
        }

        public async Task<Brand> GetByIdAsync(int brandId, params string[] includeList)
        {
            return await GetAsync(brd => brd.BrandID == brandId, includeList);
        }
    }
}
