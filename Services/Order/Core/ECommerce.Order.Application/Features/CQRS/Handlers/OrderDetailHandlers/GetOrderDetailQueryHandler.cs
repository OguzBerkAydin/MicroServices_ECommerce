using ECommerce.Order.Application.Features.CQRS.Results.OrderDetailResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
	public class GetOrderDetailQueryHandler
	{
		private readonly IRepository<OrderDetail> _repository;

		public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
		{
			_repository = repository;
		}

		public async Task<List<GetOrderDetailQueryResult>> Handle()
		{
			var values = await _repository.GetAllAsync();
			return values.Select(x => new GetOrderDetailQueryResult()
			{
				Id = x.Id,
				OrderingId = x.OrderingId,
				ProductAmount = x.ProductAmount,
				ProductId = x.ProductId,
				ProductName = x.ProductName,
				ProductPrice = x.ProductPrice,
				ProductTotalPrice = x.ProductTotalPrice,
			}).ToList();
		}
	}
}
