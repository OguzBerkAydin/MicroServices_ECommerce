namespace ECommerce.Order.Application.Features.CQRS.Commands.AddressCommands
{
	public class AddAddressCommand
	{
		public string UserId { get; set; }
		public string District { get; set; }
		public string City { get; set; }
		public string Detail { get; set; }
	}
}
