using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
	public class CargoOperationManager : ICargoOperationService
	{
		private readonly ICargoOperationDal _cargoOperationDal;

		public CargoOperationManager(ICargoOperationDal cargoOperationDal)
		{
			_cargoOperationDal = cargoOperationDal;
		}

		public void TAdd(CargoOperation entity)
		{
			_cargoOperationDal.Add(entity);
		}

		public void TDelete(int id)
		{
			_cargoOperationDal.Delete(id);
		}

		public List<CargoOperation> TGetAll()
		{
			return _cargoOperationDal.GetAll();
		}

		public CargoOperation TGetById(int id)
		{
			return _cargoOperationDal.GetById(id);
		}

		public void TUpdate(CargoOperation entity)
		{
			_cargoOperationDal.Update(entity);
		}
	}
}