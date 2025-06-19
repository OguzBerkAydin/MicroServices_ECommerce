using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.ContactDtos
{
	public class CreateContactDto
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public DateTime SendDate { get; set; } = DateTime.UtcNow;
	}

	public class UpdateContactDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
	}

	public class ResultContactDto
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Subject { get; set; }
		public string Message { get; set; }
		public bool IsRead { get; set; }
		public DateTime SendDate { get; set; }
	}
}
