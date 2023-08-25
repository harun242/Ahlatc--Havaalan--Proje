using Infrastructure.DataAccess;
using WS.Model.Entities;

namespace WS.DataAccess.Interfaces
{
    public interface IBrandRepository:IBaseRepository<Brand>
    {
        Task<List<Brand>> GetByBrandNameAsync(string brandname, params string[] includeList);

        Task<Brand> GetByIdAsync(int brandId, params string[] includeList);
    }
}
