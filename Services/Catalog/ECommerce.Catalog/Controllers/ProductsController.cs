using ECommerce.Catalog.Dtos.ProductDtos;
using ECommerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

//[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
	private readonly IProductService _productService;

	public ProductsController(IProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public async Task<ActionResult> GetAll()
	{
		var result = await _productService.GetAllAsync();
		return Ok(result);
	}

	[HttpGet("{id}")]
	public async Task<ActionResult> GetById(string id)
	{
		var result = await _productService.GetByIdAsync(id);
		if (result == null)
			return NotFound();
		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult> Add(CreateProductDto createProductDto)
	{
		await _productService.CreateAsync(createProductDto);
		return Ok("Product added successfully");
	}

	[HttpPut]
	public async Task<ActionResult> Update(UpdateProductDto updateProductDto)
	{
		await _productService.UpdateAsync(updateProductDto);
		return Ok("Product updated successfully");
	}

	[HttpDelete("{id}")]
	public async Task<ActionResult> Delete(string id)
	{
		var existing = await _productService.GetByIdAsync(id);
		if (existing == null)
			return NotFound();

		await _productService.DeleteAsync(id);
		return Ok(new { message = "Product deleted successfully" });
	}

	[HttpGet("ProductListWithCategory")]
	public async Task<IActionResult> ProductListWithCategory()
	{
		var values = await _productService.GetProductWithCategoryAsync();
		return Ok(values);
	}

	[HttpGet("ProductListWithCategoryByCategoryId")]
	public async Task<IActionResult> ProductListWithCategoryByCategoryId(string id)
	{
		var values = await _productService.GetProductWithCategoryByCategoryIdAsync(id);
		return Ok(values);
	}
}
