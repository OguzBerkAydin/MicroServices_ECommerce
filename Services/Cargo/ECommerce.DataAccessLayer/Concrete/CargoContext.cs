using ECommerce.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.Concrete
{
	public class CargoContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost,1441;Database=ECommerceCargoDb;User Id=SA;Password=SqlOguzberk3661.;MultipleActiveResultSets=true;Encrypt=False;TrustServerCertificate=True;");
		}
		public DbSet<CargoDetail> CargoDetails { get; set; }
		public DbSet<CargoOperation> CargoOperations { get; set; }
		public DbSet<CargoCustomer> CargoCustomers { get; set; }
		public DbSet<CargoCompany> CargoCompanies { get; set; }

	}
}
