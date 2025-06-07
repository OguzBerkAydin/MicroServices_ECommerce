using ECommerce.Frontend.DtoLayer.CatalogDtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CategoryController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Kategoriler";
			ViewBag.v1 = "Kategoriler Listesi";
			ViewBag.v2 = "Kategoriler Listesi";
			ViewBag.v3 = "Kategoriler Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				return View(values);
			}


			return View();
		}

		[HttpGet]
		public IActionResult Add()
		{
			ViewBag.v0 = "Category Add";
			ViewBag.v1 = "Categories";
			ViewBag.v2 = "Add new Category";
			ViewBag.v3 = "$";

			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Add(CreateCategoryDto createCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCategoryDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responsenMessage = await client.PostAsync("https://localhost:44302/api/Categories", content);

			if (responsenMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();

		}
		[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:44302/api/Categories/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Category Update";
			ViewBag.v1 = "Categories";
			ViewBag.v2 = "Update Category";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/Categories/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
				return View(value);
			}
			return RedirectToAction("Index", "Category", new { area = "Admin" });
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateCategoryDto updateCategoryDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateCategoryDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/Categories", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Category", new { area = "Admin" });
			}
			return View(updateCategoryDto);
		}

	}
}
