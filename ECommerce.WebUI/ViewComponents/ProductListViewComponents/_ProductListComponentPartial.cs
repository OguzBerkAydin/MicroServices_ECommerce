using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductListViewComponents
{
	public class _ProductListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/Products";

		public _ProductListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id = null)
		{
			var client = _httpClientFactory.CreateClient();
			HttpResponseMessage responseMessage;

			if (id == null)
				responseMessage = await client.GetAsync(_apiBaseUrl);
			else
				responseMessage = await client.GetAsync($"{_apiBaseUrl}/ProductListWithCategoryByCategoryId?id={id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}

			return View(new List<ResultProductWithCategoryDto>());
		}
	}
}
