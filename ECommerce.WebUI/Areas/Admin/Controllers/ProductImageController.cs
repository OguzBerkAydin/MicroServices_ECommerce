using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductImageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductImageController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductImageController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> Update(string id)
		{
			ViewBag.v0 = "Product Image Update";
			ViewBag.v1 = "Product Images";
			ViewBag.v2 = "Update Product Image";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/ProductImages/ProductId/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Update(UpdateProductImageDto updateProductImageDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/ProductImages", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();
		}
	}
}
