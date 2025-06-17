using ECommerce.Frontend.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CommentController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private const string BaseUrl = "https://localhost:7160/api/Comments";

		public CommentController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Yorumlar";
			ViewBag.v1 = "Yorumlar Listesi";
			ViewBag.v2 = "Yorumlar Listesi";
			ViewBag.v3 = "Yorumlar Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(BaseUrl);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
				return View(values);
			}

			return View();
		}
		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync(BaseUrl + "/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Comment", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Yorum Güncelle";
			ViewBag.v1 = "Yorumlar";
			ViewBag.v2 = "Yorum Güncelle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(BaseUrl + "/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "Comment", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCommentDto updateCommentDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCommentDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync(BaseUrl, content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Comment", new { area = "Admin" });
			}
			return View(updateCommentDto);
		}
	}
}
