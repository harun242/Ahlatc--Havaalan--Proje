using AırportMvcUI.Areas.AdminPanel.Filters;
using Microsoft.AspNetCore.Mvc;

namespace AırportMvcUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class HomeController : Controller
    {
        [LogAspect]
        public IActionResult Index()
        {
            return View();
        }
    }
}