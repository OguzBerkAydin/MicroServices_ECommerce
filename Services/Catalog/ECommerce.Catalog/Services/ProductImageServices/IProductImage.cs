using ECommerce.Catalog.Dtos.ProductImageDtos;

namespace ECommerce.Catalog.Services.ProductImageServices
{
	public interface IProductImageService
	{
		Task<List<ResultProductImageDto>> GetAllAsync();
		Task<ResultProductImageDto> GetByIdAsync(string id);
		Task CreateAsync(CreateProductImageDto createProductImageDto);
		Task UpdateAsync(UpdateProductImageDto updateProductImageDto);
		Task DeleteAsync(string id);
	}
}
