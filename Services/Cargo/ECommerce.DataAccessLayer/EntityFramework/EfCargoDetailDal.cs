using ECommerce.DataAccessLayer.Abstract;
using ECommerce.DataAccessLayer.Concrete;
using ECommerce.DataAccessLayer.Repositories;
using ECommerce.EntityLayer.Concrete;

namespace ECommerce.DataAccessLayer.EntityFramework
{
	public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
	{
		public EfCargoDetailDal(CargoContext context) : base(context)
		{
		}
	}

}
