using ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class AddAddressCommandHandler
	{
		private readonly IRepository<Address> _repository;

		public AddAddressCommandHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task Handle(AddAddressCommand addAddressCommand)
		{

			var address = new Address
			{
				UserId = addAddressCommand.UserId,
				District = addAddressCommand.District,
				City = addAddressCommand.City,
				Detail = addAddressCommand.Detail
			};

			await _repository.AddAsync(address);
		}

	}
}
