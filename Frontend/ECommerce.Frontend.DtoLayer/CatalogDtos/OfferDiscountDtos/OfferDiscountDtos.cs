using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CatalogDtos.OfferDiscountDtos
{
	public class CreateOfferDiscountDto
	{
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}

	public class UpdateOfferDiscountDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}

	public class ResultOfferDiscountDto
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string SubTitle { get; set; }
		public string ImageUri { get; set; }
		public string ButtonName { get; set; }
	}
}
