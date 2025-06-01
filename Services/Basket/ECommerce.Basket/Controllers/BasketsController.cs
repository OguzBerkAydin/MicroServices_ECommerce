using ECommerce.Basket.Dtos;
using ECommerce.Basket.LoginServices;
using ECommerce.Basket.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Basket.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BasketsController : ControllerBase
	{
		private readonly IBasketService _basketService;
		private readonly ILoginService _loginService;

		public BasketsController(IBasketService basketService, ILoginService loginService)
		{
			_basketService = basketService;
			_loginService = loginService;
		}
		[HttpGet]
		public async Task<IActionResult> GetBasket()
		{
			var value = _basketService.GetBasket(_loginService.GetUserId);
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> SaveBasket(BasketTotalDto basketTotalDto)
		{
			if (basketTotalDto == null)
			{
				return BadRequest();
			}
			basketTotalDto.UserId = _loginService.GetUserId;
			await _basketService.SaveBasket(basketTotalDto);
			return Ok("Changes saved successfuly");
		}
		[HttpDelete]
		public async Task<IActionResult> DeleteBasket()
		{
			await _basketService.DeleteBasket(_loginService.GetUserId);
			return Ok("Basket deleted successfully");
		}
	}
}
