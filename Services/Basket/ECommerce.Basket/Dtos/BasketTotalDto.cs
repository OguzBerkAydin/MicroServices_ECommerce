namespace ECommerce.Basket.Dtos
{
	public class BasketTotalDto
	{
		public string UserId { get; set; }
		public string DiscountCode { get; set; }
		public int? DiscountRate { get; set; }
		public List<BasketItemDto> BasketItems { get; set; }
		public decimal TotalPrice { get => BasketItems.Sum(item => item.Price * item.Quantity); }
		public decimal TotalPriceWithDiscount { get => TotalPrice - (DiscountRate != null ? (DiscountRate.Value / 100 * TotalPrice) : 0); }
	}
}
