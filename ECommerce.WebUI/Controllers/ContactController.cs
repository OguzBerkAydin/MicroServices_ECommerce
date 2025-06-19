using ECommerce.Frontend.DtoLayer.CatalogDtos.ContactDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ECommerce.WebUI.Controllers
{
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private const string ApiUrl = "https://localhost:44302/api/Contacts";

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(CreateContactDto createContactDto)
		{
			createContactDto.IsRead = false; // Default value for IsRead

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync(ApiUrl, content);

			if (response.IsSuccessStatusCode)
			{
				ViewBag.Message = "Message successfully sent";
				return View(); 
			}

			ViewBag.Message = "An error occurred. Please try again.";
			return View(createContactDto); 
		}
	}
}
