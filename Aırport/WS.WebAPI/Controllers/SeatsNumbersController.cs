using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.SeatNumber;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsNumbersController : BaseController
    {
        private readonly ISeatNumberBs _seatNumberBs;


        public SeatsNumbersController(ISeatNumberBs seatNumberBs)
        {
            _seatNumberBs = seatNumberBs;
        }


        #region SWAGGER DOC

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SeatNumberGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var response = await _seatNumberBs.GetSeatNumberAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SeatNumberGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _seatNumberBs.GetByIdAsync(id);
            return SendResponse(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<SeatNumberGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]

        #endregion

        [HttpPost]
        public async Task<ActionResult> SaveNewProduct([FromBody] SeatNumberPostDto dto)
        {
            var response = await _seatNumberBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.ExpeditionID }, response.Data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] SeatNumberPutDto dto)
        {
            var response = await _seatNumberBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _seatNumberBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
