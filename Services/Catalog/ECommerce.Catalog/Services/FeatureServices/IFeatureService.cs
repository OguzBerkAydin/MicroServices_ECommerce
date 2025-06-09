using ECommerce.Catalog.Dtos.FeatureDtos;

namespace ECommerce.Catalog.Services.FeatureServices
{
	public interface IFeatureService
	{
		Task<List<ResultFeatureDto>> GetAllAsync();
		Task<ResultFeatureDto> GetByIdAsync(string id);
		Task CreateAsync(CreateFeatureDto createCategoryDto);
		Task UpdateAsync(UpdateFeatureDto updateCategoryDto);
		Task DeleteAsync(string id);
	}
}
