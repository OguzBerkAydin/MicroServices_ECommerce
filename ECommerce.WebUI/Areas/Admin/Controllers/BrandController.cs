using ECommerce.Frontend.DtoLayer.CatalogDtos.BrandDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BrandController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BrandController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Markalar";
			ViewBag.v1 = "Markalar Listesi";
			ViewBag.v2 = "Markalar Listesi";
			ViewBag.v3 = "Markalar Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/Brands");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "Brand Add";
			ViewBag.v1 = "Brands";
			ViewBag.v2 = "Add new Brand";
			ViewBag.v3 = "$";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateBrandDto createBrandDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createBrandDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44302/api/Brands", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}
			return View();
		}

		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:44302/api/Brands/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Brand Update";
			ViewBag.v1 = "Brands";
			ViewBag.v2 = "Update Brand";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/Brands/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "Brand", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateBrandDto updateBrandDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBrandDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/Brands", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Brand", new { area = "Admin" });
			}
			return View(updateBrandDto);
		}
	}
}
