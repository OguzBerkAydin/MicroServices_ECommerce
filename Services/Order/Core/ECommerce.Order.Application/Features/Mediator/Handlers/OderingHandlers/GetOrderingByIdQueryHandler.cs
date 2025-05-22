using ECommerce.Order.Application.Features.Mediator.Queries.OrderingResult;
using ECommerce.Order.Application.Features.Mediator.Results.OrderingResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using MediatR;

namespace ECommerce.Order.Application.Features.Mediator.Handlers.OderingHandlers
{
	public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
	{
		private readonly IRepository<Ordering> _repository;

		public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
		{
			_repository = repository;
		}

		public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
		{
			var value = await _repository.GetByIdAsync(request.Id);
			return new GetOrderingByIdQueryResult
			{
				Id = value.Id,
				OrderDate = value.OrderDate,
				TotalPrice = value.TotalPrice,
				UserId = value.UserId,
			};
		}
	}
}
