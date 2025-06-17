namespace ECommerce.Comment.Entities
{
	public class UserComment
	{
		public int Id { get; set; }
		public int NameSurname { get; set; }
		public string Email { get; set; }
		public string? ImageUri { get; set; }
		public int Rate { get; set; }
		public bool Status { get; set; }
		//public string UserId { get; set; }
		public string ProductId { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;


	}
}
