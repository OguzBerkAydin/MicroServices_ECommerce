using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class DeleteAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;

		public DeleteAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteAddressCommand deleteAddressCommand )
		{
			var value = await _repository.GetByIdAsync(deleteAddressCommand.Id);
			await _repository.DeleteAsync(value.Id);
		}
	}
}
