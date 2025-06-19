using ECommerce.Catalog.Dtos.ContactDtos;

namespace ECommerce.Catalog.Services.ContactServices
{
	public interface IContactService
	{
		Task<List<ResultContactDto>> GetAllAsync();
		Task<ResultContactDto> GetByIdAsync(string id);
		Task CreateAsync(CreateContactDto createContactDto);
		Task UpdateAsync(UpdateContactDto updateContactDto);
		Task DeleteAsync(string id);
	}
}
