using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListPaginationPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
