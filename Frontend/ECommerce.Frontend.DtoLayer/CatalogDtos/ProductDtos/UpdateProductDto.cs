namespace ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDtos
{
	public class UpdateProductDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string ImageUri { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string CategoryId { get; set; }
	}
}
