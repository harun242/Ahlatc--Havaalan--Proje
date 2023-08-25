using Infrastructure.Utilities.ApiResponses;
using WS.Model.Dtos.Brand;
using WS.Model.Entities;

namespace WS.Business.Interfaces
{
    public interface IBrandBs
    {
        Task<ApiResponse<List<BrandGetDto>>> GetBrandAsync(params string[] includeList);
        Task<ApiResponse<List<BrandGetDto>>> GetByBrandNameAsync(string brandname, params string[] includeList);
        Task<ApiResponse<BrandGetDto>> GetByIdAsync(int brandId, params string[] includeList);

        Task<ApiResponse<Brand>> InsertAsync(BrandPostDto dto);
        Task<ApiResponse<NoData>> UpdateAsync(BrandPutDto dto);
        Task<ApiResponse<NoData>> DeleteAsync(int id);
    }
}
