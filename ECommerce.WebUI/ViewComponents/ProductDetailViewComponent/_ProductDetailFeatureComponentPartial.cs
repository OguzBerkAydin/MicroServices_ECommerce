using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductDetailViewComponent
{
	public class _ProductDetailFeatureComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/Products/";

		public _ProductDetailFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(_apiBaseUrl + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultProductDto>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
