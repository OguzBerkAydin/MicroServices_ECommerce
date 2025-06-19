using ECommerce.Frontend.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.WebUI.ViewComponents.ProductDetailViewComponent
{
	public class _ProductDetailReviewComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:7160/api/Comments/ByProductId/";

		public _ProductDetailReviewComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(string id)
		{
			ViewBag.ProductId = id;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(_apiBaseUrl + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

				return View(values);
			}

			return View();
		}
	}
}
