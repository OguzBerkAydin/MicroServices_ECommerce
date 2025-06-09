using ECommerce.Catalog.Dtos.FeatureSliderDtos;

namespace ECommerce.Catalog.Services.FeatureSliderServices
{
	public interface IFeatureSliderService
	{
		Task<List<ResultFeatureSliderDto>> GetAllAsync();
		Task<ResultFeatureSliderDto> GetByIdAsync(string id);
		Task CreateAsync(CreateFeatureSliderDto createCategoryDto);
		Task UpdateAsync(UpdateFeatureSliderDto updateCategoryDto);
		Task DeleteAsync(string id);
		Task ChangeFeatureSliderStatusAsync(string id, bool status);
	}
}
