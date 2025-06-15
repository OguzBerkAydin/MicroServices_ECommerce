using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Dtos.ProductImageDtos;
using ECommerce.Catalog.Services.ProductImageServices;
using ECommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductImagesController : ControllerBase
	{
		private readonly IProductImageService _productImageService;

		public ProductImagesController(IProductImageService productImageService)
		{
			_productImageService = productImageService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _productImageService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetById(string id)
		{
			var result = await _productImageService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}
		[HttpGet("ProductId/{id}")]
		public async Task<ActionResult> GetByIdImage(string id)
		{
			var result = await _productImageService.GetByIdImageAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateProductImageDto createProductImageDto)
		{
			await _productImageService.CreateAsync(createProductImageDto);
			return Ok("Product image added successfully");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateProductImageDto updateProductImageDto)
		{
			await _productImageService.UpdateAsync(updateProductImageDto);
			return Ok("Product image updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var existing = await _productImageService.GetByIdAsync(id);
			if (existing == null)
				return NotFound();

			await _productImageService.DeleteAsync(id);
			return Ok(new { message = "Product image deleted successfully" });
		}
	}
}
