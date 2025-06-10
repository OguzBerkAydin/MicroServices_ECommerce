using ECommerce.Catalog.Dtos.AboutDtos;
using ECommerce.Catalog.Services.AboutServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AboutsController : ControllerBase
	{
		private readonly IAboutService _aboutService;
		public AboutsController(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}
		[HttpGet]
		public async Task<ActionResult<List<ResultAboutDto>>> GetAll()
		{
			var result = await _aboutService.GetAllAsync();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ResultAboutDto>> GetById(string id)
		{
			var result = await _aboutService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
		[HttpPost]
		public async Task<ActionResult> Add(CreateAboutDto createAboutDto)
		{
			await _aboutService.CreateAsync(createAboutDto);
			return Ok("About added successfully");
		}
		[HttpPut]
		public async Task<ActionResult> Update(UpdateAboutDto updateAboutDto)
		{
			await _aboutService.UpdateAsync(updateAboutDto);
			return Ok("About updated successfully");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _aboutService.DeleteAsync(id);
			return Ok("About deleted successfully");
		}
	}
}
