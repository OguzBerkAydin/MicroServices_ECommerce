using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class AdressesController : ControllerBase
	{
		private readonly GetAddressQueryHandler _getAddressQueryHandler;
		private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
		private readonly AddAddressCommandHandler _addAddressCommandHandler;
		private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
		private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;

		public AdressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, AddAddressCommandHandler addAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler)
		{
			_getAddressQueryHandler = getAddressQueryHandler;
			_getAddressByIdQueryHandler = getAddressByIdQueryHandler;
			_addAddressCommandHandler = addAddressCommandHandler;
			_updateAddressCommandHandler = updateAddressCommandHandler;
			_deleteAddressCommandHandler = deleteAddressCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _getAddressQueryHandler.Handle();
			return Ok(values);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddAddressCommand command)
		{
			await _addAddressCommandHandler.Handle(command);
			return Ok("Address added successfuly");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateAddressCommand command)
		{
			await _updateAddressCommandHandler.Handle(command);
			return Ok("address updated successfuly");
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(DeleteAddressCommand command)
		{
			await _deleteAddressCommandHandler.Handle(command);
			return Ok("Address deleted successfuly");
		}
	}
}
