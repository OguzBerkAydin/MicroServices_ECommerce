﻿using ECommerce.Order.Application.Features.CQRS.Queries.AddressQueries;
using ECommerce.Order.Application.Features.CQRS.Results.AddressResults;
using ECommerce.Order.Application.Interfaces;
using ECommerce.Order.Domain.Entities;

namespace ECommerce.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
	public class GetAddressByIdQueryHandler
	{
		private readonly IRepository<Address> _repository;

		public GetAddressByIdQueryHandler(IRepository<Address> repository)
		{
			_repository = repository;
		}

		public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
		{
			var value = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
			return new GetAddressByIdQueryResult()
			{
				Id = value.Id,
				City = value.City,
				Detail = value.Detail,
				District = value.District,
				UserId = value.UserId
			};
		}
	}
}
