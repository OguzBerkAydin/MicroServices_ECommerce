using ECommerce.Catalog.Dtos.SpecialOfferDtos;
using ECommerce.Catalog.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ECommerce.Catalog.Services.SpecialOfferServices
{
	public interface ISpecialOfferService
	{
		Task<List<ResultSpecialOfferDto>> GetAllAsync();
		Task<ResultSpecialOfferDto> GetByIdAsync(string id);
		Task CreateAsync(CreateSpecialOfferDto createSpecialOfferDto);
		Task UpdateAsync(UpdateSpecialOfferDto updateSpecialOfferDto);
		Task DeleteAsync(string id);
	}
}
