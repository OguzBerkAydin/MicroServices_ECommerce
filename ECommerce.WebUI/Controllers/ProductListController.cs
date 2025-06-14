using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		public IActionResult Index(string id)
		{
			ViewBag.CategoryId = id; 
			return View();
		}
		public IActionResult ProductDetail(string id)
		{
			ViewBag.ProductId = id;
			return View();
		}
	}
}
