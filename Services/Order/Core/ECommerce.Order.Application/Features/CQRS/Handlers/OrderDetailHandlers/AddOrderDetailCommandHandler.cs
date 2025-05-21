using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class AddOrderDetailCommandHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public AddOrderDetailCommandHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}
		public async Task Handle(AddOrderDetailCommand command)
		{
			var orderDetail = new OrderDetail()
			{
				OrderingId = command.OrderingId,
				ProductAmount = command.ProductAmount,
				ProductId = command.ProductId,
				ProductName = command.ProductName,
				ProductPrice = command.ProductPrice,
				ProductTotalPrice = command.ProductTotalPrice,
			};
			await _repository.AddAsync(orderDetail);
		}
	}
}
