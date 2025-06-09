using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.SpecialOfferDtos
{
	public class CreateSpecialOfferDto
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}

	public class UpdateSpecialOfferDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}

	public class ResultSpecialOfferDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
	}
}
