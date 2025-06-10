using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.BrandDtos
{
	
		public class CreateBrandDto
		{
			public string Name { get; set; }
			public string ImageUri { get; set; }
		}

		public class UpdateBrandDto
		{
			public string Id { get; set; }
			public string Name { get; set; }
			public string ImageUri { get; set; }
		}

		public class ResultBrandDto
		{
			public string Id { get; set; }
			public string Name { get; set; }
			public string ImageUri { get; set; }
		}
	
}
