using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.ProductDetailDtos
{
	public class CreateProductDetailDto
	{
		public string ProductId { get; set; }
		public string Info { get; set; }
		public string Description { get; set; }
	}
	public class ResultProductDetailDto
	{
		public string Id { get; set; }
		public string Info { get; set; }
		public string Description { get; set; }
		public string ProductId { get; set; }
	}
	public class UpdateProductDetailDto
	{
		public string Id { get; set; }
		public string Info { get; set; }
		public string Description { get; set; }
		public string ProductId { get; set; }
	}
}
