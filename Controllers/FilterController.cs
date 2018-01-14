using System.Linq;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using TelerikAspNetCoreApp.EF;

namespace TelerikAspNetCoreApp.Controllers
{
    public class FilterController : Controller
    {
        QuickAppContext db = new QuickAppContext();

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult ClientFiltering_GetProducts([DataSourceRequest]DataSourceRequest request)
        {
            var result = db.AppProducts.Select(item => new { item.Id, item.Name}).ToList();

            //var dsResult = result.ToDataSourceResult(request);
            return Json(result);
        }
    }
}