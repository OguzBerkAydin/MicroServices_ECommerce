using ECommerce.Catalog.Dtos.CategoryDtos;

namespace ECommerce.Catalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllAsync();
		Task<ResultCategoryDto> GetByIdAsync(string id);
		Task CreateAsync(CreateCategoryDto createCategoryDto);
		Task UpdateAsync(UpdateCategoryDto updateCategoryDto);
		Task DeleteAsync(string id);
	}
}
