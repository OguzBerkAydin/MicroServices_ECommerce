using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.ProductImageDtos
{
	public class CreateProductImageDto
	{
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }
		public string ProductId { get; set; }
	}

	public class ResultProductImageDto
	{
		public string Id { get; set; }
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }
		public string ProductId { get; set; }
	}

	public class UpdateProductImageDto
	{
		public string Id { get; set; }
		public string Image1 { get; set; }
		public string Image2 { get; set; }
		public string Image3 { get; set; }
		public string ProductId { get; set; }
	}
}
