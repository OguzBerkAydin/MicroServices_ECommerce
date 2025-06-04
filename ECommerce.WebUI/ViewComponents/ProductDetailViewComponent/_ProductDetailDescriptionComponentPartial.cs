using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ProductDetailViewComponent
{
	public class _ProductDetailDescriptionComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
