using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ContactViewComponent
{
	public class _ContactComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
