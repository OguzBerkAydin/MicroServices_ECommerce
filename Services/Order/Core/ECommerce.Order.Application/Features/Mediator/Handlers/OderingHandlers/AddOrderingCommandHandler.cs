using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OderingHandlers
{
	public class AddOrderingCommandHandler : IRequestHandler<AddOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;

		public AddOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(AddOrderingCommand request, CancellationToken cancellationToken)
		{
			var ordering = new Ordering()
			{
				OrderDate = request.OrderDate,
				TotalPrice = request.TotalPrice,
				UserId = request.UserId,

			};

			await _repository.AddAsync(ordering);
		}
	}
}
