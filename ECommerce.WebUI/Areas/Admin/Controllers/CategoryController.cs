using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			ViewBag.v0 = "Kategoriler";
			ViewBag.v1 = "Kategoriler Listesi";
			ViewBag.v2 = "Kategoriler Listesi";
			ViewBag.v3 = "Kategoriler Listesi";
			return View();
		}
	}
}
