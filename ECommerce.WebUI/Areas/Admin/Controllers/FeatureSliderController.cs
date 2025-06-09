using ECommerce.Frontend.DtoLayer.CatalogDtos.FeatureSliderDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class FeatureSliderController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/FeatureSliders"; 

		public FeatureSliderController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Feature Slider";
			ViewBag.v1 = "Feature Slider Listesi";
			ViewBag.v2 = "Feature Slider Listesi";
			ViewBag.v3 = "Feature Slider Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(_apiBaseUrl);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "Feature Slider Ekle";
			ViewBag.v1 = "Feature Slider";
			ViewBag.v2 = "Yeni Feature Slider Ekle";
			ViewBag.v3 = "$";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateFeatureSliderDto createFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureSliderDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync(_apiBaseUrl, content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}
			return View();
		}

		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Feature Slider Güncelle";
			ViewBag.v1 = "Feature Slider";
			ViewBag.v2 = "Feature Slider Güncelle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"{_apiBaseUrl}/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureSliderDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync(_apiBaseUrl, content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
			}
			return View(updateFeatureSliderDto);
		}
	}
}
