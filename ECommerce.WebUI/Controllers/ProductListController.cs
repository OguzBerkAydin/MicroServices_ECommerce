using ECommerce.Frontend.DtoLayer.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace ECommerce.WebUI.Controllers
{
	public class ProductListController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ProductListController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index(string id)
		{
			ViewBag.CategoryId = id; 
			return View();
		}
		public IActionResult ProductDetail(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return NotFound();
			}

			return View(model: id);
		}

		[HttpPost]
		public async Task<IActionResult> AddComment(CreateCommentDto dto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(dto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7160/api/Comments", content);

			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("ProductDetail", new { id = dto.ProductId });
			}

			return View("Error");
		}
	}
}
