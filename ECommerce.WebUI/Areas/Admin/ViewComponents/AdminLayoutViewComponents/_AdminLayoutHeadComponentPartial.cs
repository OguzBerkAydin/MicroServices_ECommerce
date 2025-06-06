using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.Areas.Admin.ViewComponents.AdminLayoutViewComponents
{
	public class _AdminLayoutHeadComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
	public class _AdminLayoutSidebarComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
