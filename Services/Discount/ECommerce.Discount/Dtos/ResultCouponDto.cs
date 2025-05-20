namespace ECommerce.Discount.Dtos
{
	public class ResultCouponDto
	{
		public int Id { get; set; }
		public string Code { get; set; } = string.Empty;
		public int Rate { get; set; }
		public bool IsActive { get; set; }
		public DateTime ValidDate { get; set; }
	}
}
