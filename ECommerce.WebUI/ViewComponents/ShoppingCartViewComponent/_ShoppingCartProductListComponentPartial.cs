﻿using Microsoft.AspNetCore.Mvc;

namespace ECommerce.WebUI.ViewComponents.ShoppingCartViewComponent
{
	public class _ShoppingCartProductListComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
