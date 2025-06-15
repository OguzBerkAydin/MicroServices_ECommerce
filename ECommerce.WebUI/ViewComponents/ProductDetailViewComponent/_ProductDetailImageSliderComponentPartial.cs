using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductDetailViewComponent
{
	public class _ProductDetailImageSliderComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/ProductImages/ProductId/";

		public _ProductDetailImageSliderComponentPartial(IHttpClientFactory httpClientFactory)
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
				var values = JsonConvert.DeserializeObject<ResultProductImageDto>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
