using ECommerce.Catalog.Dtos.FeatureDtos;
using ECommerce.Catalog.Services.FeatureServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FeaturesController : ControllerBase
	{
		private readonly IFeatureService _featureService;

		public FeaturesController(IFeatureService featureService)
		{
			_featureService = featureService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResultFeatureDto>>> GetAll()
		{
			var result = await _featureService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResultFeatureDto>> GetById(string id)
		{
			var result = await _featureService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateFeatureDto createFeatureDto)
		{
			await _featureService.CreateAsync(createFeatureDto);
			return Ok("Feature added successfully");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateFeatureDto updateFeatureDto)
		{
			await _featureService.UpdateAsync(updateFeatureDto);
			return Ok("Feature updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _featureService.DeleteAsync(id);
			return Ok("Feature deleted successfully");
		}
	}
}
