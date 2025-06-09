namespace ECommerce.Catalog.Dtos.SpecialOfferDtos
{
	public class CreateSpecialOfferDto
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}

	public class UpdateSpecialOfferDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}

	public class ResultSpecialOfferDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}
}
