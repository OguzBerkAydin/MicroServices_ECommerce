using ECommerce.Frontend.DtoLayer.CatalogDtos.OfferDiscountDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class OfferDiscountController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OfferDiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "İndirimler";
			ViewBag.v1 = "İndirim Listesi";
			ViewBag.v2 = "İndirim Listesi";
			ViewBag.v3 = "İndirim Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/OfferDiscounts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultOfferDiscountDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "İndirim Ekle";
			ViewBag.v1 = "İndirimler";
			ViewBag.v2 = "Yeni İndirim Ekle";
			ViewBag.v3 = "$";
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateOfferDiscountDto createOfferDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createOfferDiscountDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44302/api/OfferDiscounts", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}
			return View();
		}

		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:44302/api/OfferDiscounts/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "İndirim Güncelle";
			ViewBag.v1 = "İndirimler";
			ViewBag.v2 = "İndirim Güncelle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/OfferDiscounts/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateOfferDiscountDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateOfferDiscountDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/OfferDiscounts", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "OfferDiscount", new { area = "Admin" });
			}
			return View(updateOfferDiscountDto);
		}
	}
}
