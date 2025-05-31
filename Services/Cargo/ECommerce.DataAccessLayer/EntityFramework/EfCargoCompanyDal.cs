using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccessLayer.EntityFramework
{
	public class EfCargoCompanyDal : GenericRepository<CargoCompany>, ICargoCompanyDal
	{
		public EfCargoCompanyDal(CargoContext context) : base(context)
		{
		}
	}
}
