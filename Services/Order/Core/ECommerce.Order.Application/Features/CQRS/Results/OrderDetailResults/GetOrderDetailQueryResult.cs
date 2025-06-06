﻿namespace ECommerce.Order.Application.Features.CQRS.Results.OrderDetailResults
{
	public class GetOrderDetailQueryResult
	{
		public int Id { get; set; }
		public int OrderingId { get; set; }
		public string ProductId { get; set; }
		public string ProductName { get; set; }
		public decimal ProductPrice { get; set; }
		public decimal ProductTotalPrice { get; set; }
		public int ProductAmount { get; set; }
	}
}
