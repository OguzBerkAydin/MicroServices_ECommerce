﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
	public class SpecialOffer
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}
}
