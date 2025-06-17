using ECommerce.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Comment.Context
{
	public class CommentContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1442;Database=ECommerceCommentDb;User Id=SA;Password=SqlOguzberk3661.;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True;");
		}
		public DbSet<UserComment> UserComments { get; set; }
	}
}
