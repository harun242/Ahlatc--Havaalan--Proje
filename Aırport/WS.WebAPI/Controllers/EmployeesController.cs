using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Employee;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : BaseController
    {
        private readonly IEmployeeBs _employeeBs;


        public EmployeesController(IEmployeeBs employeeBs)
        {
            _employeeBs = employeeBs;

        }


        #region SWAGGER DOC

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var response = await _employeeBs.GetEmployeeAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _employeeBs.GetByIdAsync(id);
            return SendResponse(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<EmployeeGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]

        #endregion

        [HttpPost]
        public async Task<ActionResult> SaveNewEmployee([FromBody] EmployeePostDto dto)
        {
            var response = await _employeeBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.EmployeeID }, response.Data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] EmployeePutDto dto)
        {
            var response = await _employeeBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var response = await _employeeBs.DeleteAsync(id);
            return SendResponse(response);
        }
    }
}
