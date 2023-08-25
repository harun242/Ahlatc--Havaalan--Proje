using Infrastructure.Utilities.ApiResponses;
using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Mvc;
using WS.Business.Interfaces;
using WS.Model.Dtos.AdminPanelUser;

namespace WS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAdminPanelUserBs _adminPanelUserBs;
        private readonly IConfiguration _configuration;

        public AuthController(IAdminPanelUserBs adminPanelUserBs, IConfiguration configuration)
        {
            _adminPanelUserBs = adminPanelUserBs;
            _configuration = configuration;
        }

        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AccessToken>))]
        [HttpGet("gettoken")]
        public async Task<ActionResult> GetToken()
        {

            var accessToken = new JwtGenerator(_configuration).GenerateAccessToken();
            var response = new ApiResponse<AccessToken>();
            response.Data = accessToken;
            response.StatusCode = 200;

            return SendResponse(response);

        }

        #region SWAGGER DOC
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<AdminPanelUserDto>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))] 
        #endregion

        [HttpGet("login")]
        public async Task<ActionResult> LogIn([FromQuery] string userName, [FromQuery] string password)
        {
            var response = await _adminPanelUserBs.LogInAsync(userName, password);
            return SendResponse(response);

        }
    }
}

