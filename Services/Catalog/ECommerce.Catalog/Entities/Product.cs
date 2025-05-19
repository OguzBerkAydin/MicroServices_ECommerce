using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
	public class Product
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Name { get; set; }
		public string ImageUri { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public string CategoryId { get; set; }
		[BsonIgnore]
		public Category Category { get; set; }
	}

}
