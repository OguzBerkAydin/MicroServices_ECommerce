using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.DataAccessLayer.EntityFramework
{
	public class EfCargoOperationDal : GenericRepository<CargoOperation>, ICargoOperationDal
	{
		public EfCargoOperationDal(CargoContext context) : base(context)
		{
		}
	}

}
