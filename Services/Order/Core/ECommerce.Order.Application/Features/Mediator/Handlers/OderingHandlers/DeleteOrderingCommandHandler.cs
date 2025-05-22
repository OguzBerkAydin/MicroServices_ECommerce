using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OderingHandlers
{
	public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
	{
		private readonly IRepository<Ordering> _repository;

		public DeleteOrderingCommandHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			await _repository.DeleteAsync(value.Id);
		}
	}
}
