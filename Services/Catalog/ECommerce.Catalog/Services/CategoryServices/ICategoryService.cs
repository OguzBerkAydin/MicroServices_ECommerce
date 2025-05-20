using ECommerce.Catalog.Dtos.CategoryDtos;
using ECommerce.Catalog.Entities;

namespace ECommerce.Catalog.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<List<ResultCategoryDto>> GetAllAsync();
		Task<ResultCategoryDto> GetByIdAsync(string id);
		Task CreateAsync(CreateCategoryDto entity);
		Task UpdateAsync(UpdateCategoryDto entity);
		Task DeleteAsync(string id);
	}
}
