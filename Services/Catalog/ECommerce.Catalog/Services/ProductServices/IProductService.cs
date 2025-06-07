using ECommerce.Catalog.Dtos.ProductDtos;

namespace ECommerce.Catalog.Services.ProductServices
{
	public interface IProductService
	{
		Task<List<ResultProductDto>> GetAllAsync();
		Task<ResultProductDto> GetByIdAsync(string id);
		Task CreateAsync(CreateProductDto createProductDto);
		Task UpdateAsync(UpdateProductDto updateProductDto);
		Task DeleteAsync(string id);
		Task<List<ResultProductWithCategoryDto>> GetProductWithCategoryAsync();
	}
}
