using ECommerce.Catalog.Dtos.OfferDiscountDtos;
using ECommerce.Catalog.Services.OfferDiscountServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OfferDiscountsController : ControllerBase
	{
		private readonly IOfferDiscountService _offerDiscountService;

		public OfferDiscountsController(IOfferDiscountService offerDiscountService)
		{
			_offerDiscountService = offerDiscountService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResultOfferDiscountDto>>> GetAll()
		{
			var result = await _offerDiscountService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResultOfferDiscountDto>> GetById(string id)
		{
			var result = await _offerDiscountService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateOfferDiscountDto createOfferDiscountDto)
		{
			await _offerDiscountService.CreateAsync(createOfferDiscountDto);
			return Ok("Offer Discount added successfully");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateOfferDiscountDto updateOfferDiscountDto)
		{
			await _offerDiscountService.UpdateAsync(updateOfferDiscountDto);
			return Ok("Offer Discount updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _offerDiscountService.DeleteAsync(id);
			return Ok("Offer Discount deleted successfully");
		}
	}
}
