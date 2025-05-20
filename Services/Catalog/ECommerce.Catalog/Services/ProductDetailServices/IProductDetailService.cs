using ECommerce.Catalog.Dtos.ProductDetailDtos;

namespace ECommerce.Catalog.Services.ProductDetailServices
{
	public interface IProductDetailService
	{
		Task<List<ResultProductDetailDto>> GetAllAsync();
		Task<ResultProductDetailDto> GetByIdAsync(string id);
		Task CreateAsync(CreateProductDetailDto createProductDetailDto);
		Task UpdateAsync(UpdateProductDetailDto updateProductDetailDto);
		Task DeleteAsync(string id);
	}
}
