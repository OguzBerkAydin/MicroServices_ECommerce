using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class UpdateOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task Handle(UpdateOrderDetailCommand command)
		{
			var value = await _repository.GetByIdAsync(command.Id);
			value.ProductName = command.ProductName;
			value.ProductPrice = command.ProductPrice;
			value.ProductTotalPrice = command.ProductTotalPrice;
			value.ProductId = command.ProductId;
			value.OrderingId = command.OrderingId;
			value.ProductAmount = command.ProductAmount;

			await _repository.UpdateAsync(value);
		}
	}
}
