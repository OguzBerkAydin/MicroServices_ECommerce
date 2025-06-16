using ECommerce.Catalog.Dtos.ProductDetailDtos;
using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Services.ProductDetailServices;
using ECommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductDetailsController : ControllerBase
	{
		private readonly IProductDetailService _productDetailService;

		public ProductDetailsController(IProductDetailService productDetailService)
		{
			_productDetailService = productDetailService;
		}

		[HttpGet]
		public async Task<ActionResult> GetAll()
		{
			var result = await _productDetailService.GetAllAsync();
			return Ok(result);
		}
		[HttpGet("ProductId/{id}")]
		public async Task<ActionResult> GetByProductId(string id)
		{
			var result = await _productDetailService.GetByProductIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult> GetById(string id)
		{
			var result = await _productDetailService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateProductDetailDto createProductDetailDto)
		{
			await _productDetailService.CreateAsync(createProductDetailDto);
			return Ok("Product detail added successfully");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateProductDetailDto updateProductDetailDto)
		{
			await _productDetailService.UpdateAsync(updateProductDetailDto);
			return Ok("Product detail updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			var existing = await _productDetailService.GetByIdAsync(id);
			if (existing == null)
				return NotFound();

			await _productDetailService.DeleteAsync(id);
			return Ok(new { message = "Product detail deleted successfully" });
		}
	}
}
