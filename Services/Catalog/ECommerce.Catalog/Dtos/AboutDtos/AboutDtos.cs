namespace ECommerce.Catalog.Dtos.AboutDtos
{
	public class ResultAboutDto
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}

	public class CreateAboutDto
	{
		public string Description { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}

	public class UpdateAboutDto
	{
		public string Id { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}