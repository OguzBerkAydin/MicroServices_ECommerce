using ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands;
using ECommerce.Order.Application.Features.Mediator.Queries.OrderingResult;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Order.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OrderingsController : ControllerBase
	{
		private readonly IMediator _mediator;

		public OrderingsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			var values = await _mediator.Send(new GetOrderingQuery());
			return Ok(values);
		}
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var value = await _mediator.Send(new GetOrderingByIdQuery(id));
			return Ok(value);
		}
		[HttpPost]
		public async Task<IActionResult> Add(AddOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ordering added successfuly");
		}
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			await _mediator.Send(new DeleteOrderingCommand(id));
			return Ok("Ordering Deleted Successfuly");
		}
		[HttpPut]
		public async Task<IActionResult> Update(UpdateOrderingCommand command)
		{
			await _mediator.Send(command);
			return Ok("Ordering updated successfuly");
		}
	}
}
