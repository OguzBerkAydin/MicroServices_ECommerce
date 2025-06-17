using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Frontend.DtoLayer.CommentDtos
{
	
	public class CreateCommentDto
	{
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string? ImageUri { get; set; }
		public int Rate { get; set; }
		public bool Status { get; set; }
		//public string UserId { get; set; }
		public string ProductId { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
	}
	public class ResultCommentDto
	{
		public int Id { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string? ImageUri { get; set; }
		public int Rate { get; set; }
		public bool Status { get; set; }
		//public string UserId { get; set; }
		public string ProductId { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
	}
	public class UpdateCommentDto
	{
		public int Id { get; set; }
		public string NameSurname { get; set; }
		public string Email { get; set; }
		public string? ImageUri { get; set; }
		public int Rate { get; set; }
		public bool Status { get; set; }
		//public string UserId { get; set; }
		public string ProductId { get; set; }
		public string Comment { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
