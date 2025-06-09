using ECommerce.Catalog.Dtos.FeatureSliderDtos;
using ECommerce.Catalog.Services.FeatureSliderServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Controllers
{
	//[Authorize] // Uncomment this line if you want to enable authorization for this controller
	[Route("api/[controller]")]
	[ApiController]
	public class FeatureSlidersController : ControllerBase
	{
		private readonly IFeatureSliderService _featureSliderService;

		public FeatureSlidersController(IFeatureSliderService featureSliderService)
		{
			_featureSliderService = featureSliderService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResultFeatureSliderDto>>> GetAll()
		{
			var result = await _featureSliderService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResultFeatureSliderDto>> GetById(string id)
		{
			var result = await _featureSliderService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateFeatureSliderDto createFeatureSliderDto)
		{
			await _featureSliderService.CreateAsync(createFeatureSliderDto);
			return Ok("Feature slider added successfully.");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateFeatureSliderDto updateFeatureSliderDto)
		{
			await _featureSliderService.UpdateAsync(updateFeatureSliderDto);
			return Ok("Feature slider updated successfully.");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _featureSliderService.DeleteAsync(id);
			return Ok("Feature slider deleted successfully.");
		}

		[HttpPut("changeStatus/{id}")]
		public async Task<ActionResult> ChangeStatus(string id, [FromQuery] bool status)
		{
			await _featureSliderService.ChangeFeatureSliderStatusAsync(id, status);
			return Ok("Feature slider status changed successfully.");
		}
	}
}