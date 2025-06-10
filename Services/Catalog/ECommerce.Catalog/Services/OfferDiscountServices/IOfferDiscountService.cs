using ECommerce.Catalog.Dtos.OfferDiscountDtos;

namespace ECommerce.Catalog.Services.OfferDiscountServices
{
	public interface IOfferDiscountService
	{
		Task<List<ResultOfferDiscountDto>> GetAllAsync();
		Task<ResultOfferDiscountDto> GetByIdAsync(string id);
		Task CreateAsync(CreateOfferDiscountDto createCategoryDto);
		Task UpdateAsync(UpdateOfferDiscountDto updateCategoryDto);
		Task DeleteAsync(string id);
	}
}
