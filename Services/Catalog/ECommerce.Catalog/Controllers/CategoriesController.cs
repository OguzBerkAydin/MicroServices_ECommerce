using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryService _categoryService;
		public CategoriesController(ICategoryService categoryService)
		{
			_categoryService = categoryService;
		}
		[HttpGet]
		public async Task<ActionResult<List<ResultCategoryDto>>> GetAll()
		{
			var result = await _categoryService.GetAllAsync();
			return Ok(result);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<ResultCategoryDto>> GetById(string id)
		{
			var result = await _categoryService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
		[HttpPost]
		public async Task<ActionResult> Add(CreateCategoryDto createCategoryDto)
		{
			await _categoryService.CreateAsync(createCategoryDto);
			return Ok("Category added successfuly");
		}
		[HttpPut]
		public async Task<ActionResult> Update(UpdateCategoryDto updateCategoryDto)
		{
			await _categoryService.UpdateAsync(updateCategoryDto);
			return Ok("Category updated successfuly");
		}
		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _categoryService.DeleteAsync(id);
			return Ok("Category deleted successfuly");
		}
	}
}
