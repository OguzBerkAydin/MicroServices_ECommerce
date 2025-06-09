using ECommerce.Frontend.DtoLayer.CatalogDtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Özellikler";
			ViewBag.v1 = "Özellik Listesi";
			ViewBag.v2 = "Özellik Listesi";
			ViewBag.v3 = "Özellik Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "Özellik Ekle";
			ViewBag.v1 = "Özellikler";
			ViewBag.v2 = "Yeni Özellik Ekle";
			ViewBag.v3 = "$";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44302/api/Features", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View();
		}

		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:44302/api/Features/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Özellik Güncelle";
			ViewBag.v1 = "Özellikler";
			ViewBag.v2 = "Özellik Güncelle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/Features/{id}");

			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "Feature", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/Features", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View(updateFeatureDto);
		}
	}
}
