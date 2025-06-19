using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ECommerce.Catalog.Dtos.ContactDtos;
using ECommerce.Catalog.Services.ContactServices;

namespace ECommerce.Catalog.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactsController : ControllerBase
	{
		private readonly IContactService _contactService;

		public ContactsController(IContactService contactService)
		{
			_contactService = contactService;
		}

		[HttpGet]
		public async Task<ActionResult<List<ResultContactDto>>> GetAll()
		{
			var result = await _contactService.GetAllAsync();
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<ResultContactDto>> GetById(string id)
		{
			var result = await _contactService.GetByIdAsync(id);
			if (result == null)
				return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult> Add(CreateContactDto createContactDto)
		{
			await _contactService.CreateAsync(createContactDto);
			return Ok("Contact added successfully");
		}

		[HttpPut]
		public async Task<ActionResult> Update(UpdateContactDto updateContactDto)
		{
			await _contactService.UpdateAsync(updateContactDto);
			return Ok("Contact updated successfully");
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(string id)
		{
			await _contactService.DeleteAsync(id);
			return Ok("Contact deleted successfully");
		}
	}
}
