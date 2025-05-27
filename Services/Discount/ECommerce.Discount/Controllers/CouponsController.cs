using ECommerce.Discount.Dtos;
using ECommerce.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Discount.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class CouponsController : ControllerBase
	{
		private readonly IDiscountService _discountService;

		public CouponsController(IDiscountService discountService)
		{
			_discountService = discountService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var coupons = await _discountService.GetAllAsync();
			return Ok(coupons);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var coupon = await _discountService.GetByIdAsync(id);
			if (coupon == null)
			{
				return NotFound();
			}
			return Ok(coupon);
		}
		[HttpPost]
		public async Task<IActionResult> Add(CreateCouponDto createCouponDto)
		{
			await _discountService.CreateAsync(createCouponDto);
			return Ok("Coupon added successfully");
		}

		[HttpDelete]
		public async Task<IActionResult> Delete(int id)
		{
			await _discountService.DeleteAsync(id);
			return Ok("Coupon deleted successfully");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateCouponDto updateCouponDto)
		{
			await _discountService.UpdateAsync(updateCouponDto);
			return Ok("Coupon updated successfully");
		}
	}
}
