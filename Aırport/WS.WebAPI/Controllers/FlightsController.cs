using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Flight;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : BaseController
    {
        private readonly IFlightBs _flightBs;


        public FlightsController(IFlightBs flightBs)
        {
            _flightBs = flightBs;
        }


        #region SWAGGER DOC

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<FlightGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var response = await _flightBs.GetRouteAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<FlightGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _flightBs.GetByIdAsync(id);
            return SendResponse(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<FlightGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]

        #endregion

        [HttpPost]
        public async Task<ActionResult> SaveNewFlight([FromBody] FlightPostDto dto)
        {
            var response = await _flightBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.RouteID }, response.Data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateFlight([FromBody] FlightPutDto dto)
        {
            var response = await _flightBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            var response = await _flightBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
