using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.FeatureDtos
{
	public class CreateFeatureDto
	{
		public string Title { get; set; }
		public string Icon { get; set; }
	}

	public class UpdateFeatureDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
	}

	public class ResultFeatureDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string Icon { get; set; }
	}
}
