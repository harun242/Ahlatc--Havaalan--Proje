using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.Customer;
using WS.Model.Entities;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseController
    {
       
            private readonly ICustomerBs _customerBs;


            public CustomersController(ICustomerBs customerBs)
            {
            _customerBs = customerBs;

            }

        #region SWAGGER DOC

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet]
        public async Task<ActionResult> GetAllBrands()
        {
            var response = await _customerBs.GetCustomerAsync();
            return SendResponse(response);
        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]
        #endregion

        [HttpGet("{id}")]

        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            var response = await _customerBs.GetByIdAsync(id);
            return SendResponse(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CustomerGetDto>>))]
        [ProducesResponseType(404, Type = typeof(string))]

        #endregion

        [HttpPost]
        public async Task<ActionResult> SaveNewProduct([FromBody] CustomerPostDto dto)
        {
            var response = await _customerBs.InsertAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = response.Data.CustomerID }, response.Data);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] CustomerPutDto dto)
        {
            var response = await _customerBs.UpdateAsync(dto);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await _customerBs.DeleteAsync(id);
            return SendResponse(response);
        }

    }
}
