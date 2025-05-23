﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.Mediator.Commands.OrderingCommands
{
	public class AddOrderingCommand : IRequest
	{
		public string UserId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
	}
}
