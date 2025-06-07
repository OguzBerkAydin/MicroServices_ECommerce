using ECommerce.Frontend.DtoLayer.CatalogDtos.CategoryDtos;
using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.v0 = "Ürünler";
			ViewBag.v1 = "Ürünler Listesi";
			ViewBag.v2 = "Ürünler Listesi";
			ViewBag.v3 = "Ürünler Listesi";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/Products/ProductListWithCategory");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultProductWithCategoryDto>>(jsonData);
				return View(values);
			}

			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Add()
		{
			ViewBag.v0 = "Ürün Ekle";
			ViewBag.v1 = "Ürünler";
			ViewBag.v2 = "Yeni Ürün Ekle";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:44302/api/Categories");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
				ViewBag.Categories = categories; 
			}

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Add(CreateProductDto createProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createProductDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:44302/api/Products", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();
		}
		//[HttpPost]
		public async Task<IActionResult> Delete(string id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync("https://localhost:44302/api/Products/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Ürün Güncelle";
			ViewBag.v1 = "Ürünler";
			ViewBag.v2 = "Ürün Güncelleme";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();

			// Fetch the product data
			var productResponse = await client.GetAsync($"https://localhost:44302/api/Products/{id}");
			if (!productResponse.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}

			var productJsonData = await productResponse.Content.ReadAsStringAsync();
			var product = JsonConvert.DeserializeObject<UpdateProductDto>(productJsonData);

			// Fetch categories
			var categoryResponse = await client.GetAsync("https://localhost:44302/api/Categories");
			if (categoryResponse.IsSuccessStatusCode)
			{
				var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
				ViewBag.Categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(categoryJsonData);
			}
			return View(product);
		}

		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductDto updateProductDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/Products", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View(updateProductDto);
		}
	}
}
