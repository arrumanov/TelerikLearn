using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Kendo.Mvc.UI;
using TelerikAspNetCoreApp.Models;
using Kendo.Mvc.Extensions;
using TelerikAspNetCoreApp.EF;

namespace TelerikAspNetCoreApp.Controllers
{
    public class GridController : Controller
    {
        QuickAppContext db = new QuickAppContext();
        public ActionResult Orders_Read([DataSourceRequest]DataSourceRequest request)
		{
            var result = Enumerable.Range(0, 50).Select(i => new OrderViewModel
            {
                OrderID = i,
                Freight = i * 10,
                OrderDate = new DateTime(2016, 9, 15).AddDays(i % 7),
				ShipName = "ShipName " + i,
				ShipCity = "ShipCity " + i
			});

			var dsResult = result.ToDataSourceResult(request);
			return Json(dsResult);
		}

        public IActionResult NewGrid()
        {
            return View();
        }

        public ActionResult ClientGrid_GetProducts()
        {
            var result = db.AppProducts.Select(item => new { item.Id, item.Name, item.BuyingPrice, item.SellingPrice, item.Description }).ToList();

            return Json(result);
        }

    }
}
