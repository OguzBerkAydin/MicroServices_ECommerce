using ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductDetailController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductDetailController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		public async Task<IActionResult> ProductsDetail(string id)
		{
			ViewBag.v0 = "Product detail Index";
			ViewBag.v1 = "Product detail";
			ViewBag.v2 = "Index Product detail";
			ViewBag.v3 = "$";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:44302/api/ProductDetails/ProductId/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
				return View(value);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> ProductsDetail(UpdateProductDetailDto updateProductDetailDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateProductDetailDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:44302/api/ProductDetails", content);

			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Product", new { area = "Admin" });
			}
			return View();
		}
	}
}
