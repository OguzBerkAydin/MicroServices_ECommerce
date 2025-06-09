using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Services.SpecialOfferServices;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class SpecialOffersController : ControllerBase
	{
		private readonly ISpecialOfferService _specialOfferService;

		public SpecialOffersController(ISpecialOfferService specialOfferService)
		{
			_specialOfferService = specialOfferService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResultSpecialOfferDto>>> GetAll()
		{
			var result = await _specialOfferService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResultSpecialOfferDto>> GetById(string id)
		{
			var result = await _specialOfferService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateSpecialOfferDto createSpecialOfferDto)
		{
			await _specialOfferService.CreateAsync(createSpecialOfferDto);
			return Ok("Special offer added successfully.");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateSpecialOfferDto updateSpecialOfferDto)
		{
			await _specialOfferService.UpdateAsync(updateSpecialOfferDto);
			return Ok("Special offer updated successfully.");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _specialOfferService.DeleteAsync(id);
			return Ok("Special offer deleted successfully.");
		}
	}
}
