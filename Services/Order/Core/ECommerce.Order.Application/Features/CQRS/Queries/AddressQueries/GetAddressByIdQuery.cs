﻿namespace ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries
{
	public class GetAddressByIdQuery
	{
		public int Id { get; set; }

		public GetAddressByIdQuery(int id)
		{
			Id = id;
		}
	}
}
