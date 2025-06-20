﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ECommerce.Catalog.Entities
{
	public class About
	{
		[BsonId]
		[BsonRepresentation(BsonType.ObjectId)]
		public string Id { get; set; }
		public string Description { get; set; }
		public string Address { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
	}
}
