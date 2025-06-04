using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ProductDetailViewComponent
{
	public class _ProductDetailReviewComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
