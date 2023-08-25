using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Brand;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        private readonly IBrandBs _brandBs;

        public BrandsController(IBrandBs brandBs)
        {
            _brandBs = brandBs;
        }

        #region SWAGGER DOC

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BrandGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var response = await _brandBs.GetBrandAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BrandGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _brandBs.GetByIdAsync(id);
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<BrandGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]

        #endregion

        [HttpPost]
        public async Task<ActionResult> SaveNewProduct([FromBody] BrandPostDto dto)
        {
            var response = await _brandBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.BrandID }, response.Data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] BrandPutDto dto)
        {
            var response = await _brandBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _brandBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
