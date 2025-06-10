namespace ECommerce.Catalog.Dtos.OfferDiscountDtos
{
	public class CreateOfferDiscountDto
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}

	public class UpdateOfferDiscountDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}

	public class ResultOfferDiscountDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}
}
