using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OderingHandlers
{
	public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;

		public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			value.OrderDate = request.OrderDate;
			value.TotalPrice = request.TotalPrice;
			value.UserId = request.UserId;
			await _repository.UpdateAsync(value);
		}
	}
}
