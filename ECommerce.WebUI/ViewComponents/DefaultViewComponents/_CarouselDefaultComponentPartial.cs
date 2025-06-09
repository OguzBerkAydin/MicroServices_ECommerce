using ECommerce.Frontend.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.DefaultViewComponents
{
	public class _CarouselDefaultComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/FeatureSliders";

		public _CarouselDefaultComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(_apiBaseUrl);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
				var activeValues = values.Where(x => x.Status).ToList();

				return View(activeValues);
			}

			return View();
		}
	}
}
