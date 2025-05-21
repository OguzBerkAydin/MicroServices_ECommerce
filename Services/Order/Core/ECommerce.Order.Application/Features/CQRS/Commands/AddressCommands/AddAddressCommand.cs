using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands
{
	public class AddAddressCommand
	{
		public string UserId { get; set; }
		public string District { get; set; }
		public string City { get; set; }
		public string Detail { get; set; }
	}
	public class UpdateAddressCommand
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public string District { get; set; }
		public string City { get; set; }
		public string Detail { get; set; }
	}
	public class DeleteAddressCommand
	{
		public int Id { get; set; }

		public DeleteAddressCommand(int id)
		{
			Id = id;
		}
	}
}
