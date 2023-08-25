using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace WS.WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {
        [NonAction] // bu bir endpoint değil dolayısıyla bu metod için bir endpoint hazırlamay falan uğraşma  
        public ActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == StatusCodes.Status204NoContent)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}

