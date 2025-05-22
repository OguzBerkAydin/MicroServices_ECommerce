using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Queries.OrderingResult
{
	public class GetOrderingByIdQuery : IRequest<GetOrderingByIdQueryResult>
	{
		public int Id { get; set; }

		public GetOrderingByIdQuery(int id)
		{
			Id = id;
		}
	}
}
