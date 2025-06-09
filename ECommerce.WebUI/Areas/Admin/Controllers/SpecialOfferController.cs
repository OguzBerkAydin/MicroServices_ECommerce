using ECommerce.Frontend.DtoLayer.CatalogDtos.SpecialOfferDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class SpecialOfferController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly string _apiBaseUrl = "https://localhost:44302/api/SpecialOffers"; // API endpoint

		public SpecialOfferController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Özel Teklifler";
			ViewBag.v1 = "Özel Teklif Listesi";
			ViewBag.v2 = "Özel Teklif Listesi";
			ViewBag.v3 = "Özel Teklif Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync(_apiBaseUrl);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSpecialOfferDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "Özel Teklif Ekle";
			ViewBag.v1 = "Özel Teklif";
			ViewBag.v2 = "Yeni Özel Teklif Ekle";
			ViewBag.v3 = "$";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateSpecialOfferDto createSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSpecialOfferDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync(_apiBaseUrl, content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View();
		}

		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"{_apiBaseUrl}/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Özel Teklif Güncelle";
			ViewBag.v1 = "Özel Teklif";
			ViewBag.v2 = "Özel Teklif Güncelle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"{_apiBaseUrl}/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateSpecialOfferDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSpecialOfferDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync(_apiBaseUrl, content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
			}
			return View(updateSpecialOfferDto);
		}
	}
}
