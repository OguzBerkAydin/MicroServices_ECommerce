using ECommerce.Discount.Dtos;

namespace ECommerce.Discount.Services
{
	public interface IDiscountService
	{
		Task<List<ResultCouponDto>> GetAllAsync();
		Task<ResultCouponDto> GetByIdAsync(int id);
		Task CreateAsync(CreateCouponDto createCouponDto);
		Task UpdateAsync(UpdateCouponDto updateCouponDto);
		Task DeleteAsync(int id);
	}
}
