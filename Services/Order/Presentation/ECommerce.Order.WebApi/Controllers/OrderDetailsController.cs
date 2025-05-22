using ECommerce.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ECommerce.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderDetailsController : ControllerBase
	{
		private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
		private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
		private readonly AddOrderDetailCommandHandler _addOrderDetailCommandHandler;
		private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
		private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;

		public OrderDetailsController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, AddOrderDetailCommandHandler addOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler)
		{
			_getOrderDetailQueryHandler = getOrderDetailQueryHandler;
			_getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
			_addOrderDetailCommandHandler = addOrderDetailCommandHandler;
			_updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
			_deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _getOrderDetailQueryHandler.Handle();
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddOrderDetailCommand command)
		{
			await _addOrderDetailCommandHandler.Handle(command);
			return Ok("OrderDetail added successfuly");
		}
		[HttpDelete]
		public async Task<IActionResult> Delete(DeleteOrderDetailCommand command)
		{
			await _deleteOrderDetailCommandHandler.Handle(command);
			return Ok("Order detail deleted successfuly");	
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderDetailCommand command)
		{
			await _updateOrderDetailCommandHandler.Handle(command);
			return Ok("Order Detail updated successfuly");
		}
	}
}
