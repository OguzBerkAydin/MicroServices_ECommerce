using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.DataAccessLayer.EntityFramework
{
	public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
	{
		public EfCargoCustomerDal(CargoContext context) : base(context)
		{
		}
	}

}
