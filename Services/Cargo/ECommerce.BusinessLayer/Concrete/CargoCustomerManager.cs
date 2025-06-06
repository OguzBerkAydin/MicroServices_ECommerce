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
	public class CargoCustomerManager : ICargoCustomerService
	{
		private readonly ICargoCustomerDal _cargoCustomerDal;

		public CargoCustomerManager(ICargoCustomerDal cargoCustomerDal)
		{
			_cargoCustomerDal = cargoCustomerDal;
		}

		public void TAdd(CargoCustomer entity)
		{
			_cargoCustomerDal.Add(entity);
		}

		public void TDelete(int id)
		{
			_cargoCustomerDal.Delete(id);
		}

		public List<CargoCustomer> TGetAll()
		{
			return _cargoCustomerDal.GetAll();
		}

		public CargoCustomer TGetById(int id)
		{
			return _cargoCustomerDal.GetById(id);
		}

		public void TUpdate(CargoCustomer entity)
		{
			_cargoCustomerDal.Update(entity);
		}
	}
}