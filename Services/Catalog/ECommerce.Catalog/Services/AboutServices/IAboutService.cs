using ECommerce.Catalog.Dtos.AboutDtos;

namespace ECommerce.Catalog.Services.AboutServices
{
	public interface IAboutService
	{
		Task<List<ResultAboutDto>> GetAllAsync();
		Task<ResultAboutDto> GetByIdAsync(string id);
		Task CreateAsync(CreateAboutDto createAboutDto);
		Task UpdateAsync(UpdateAboutDto updateAboutDto);
		Task DeleteAsync(string id);
	}
}
