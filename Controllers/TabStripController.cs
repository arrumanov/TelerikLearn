using Microsoft.AspNetCore.Mvc;

namespace TelerikAspNetCoreApp.Controllers
{
    public class TabStripController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}