using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class DeleteOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public DeleteOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(DeleteOrderDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			await _repository.DeleteAsync(value.Id);
		}
	}
}
