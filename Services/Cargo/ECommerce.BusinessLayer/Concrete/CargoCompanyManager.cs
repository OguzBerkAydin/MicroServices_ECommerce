﻿using ECommerce.BusinessLayer.Abstract;
using ECommerce.DataAccessLayer.Abstract;
using ECommerce.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BusinessLayer.Concrete
{
	public class CargoCompanyManager : ICargoCompanyService
	{
		private readonly ICargoCompanyDal _cargoCompanyDal;

		public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
		{
			_cargoCompanyDal = cargoCompanyDal;
		}

		public void TAdd(CargoCompany entity)
		{
			_cargoCompanyDal.Add(entity);
		}

		public void TDelete(int id)
		{
			_cargoCompanyDal.Delete(id);
		}

		public List<CargoCompany> TGetAll()
		{
			return _cargoCompanyDal.GetAll();
		}

		public CargoCompany TGetById(int id)
		{
			return _cargoCompanyDal.GetById(id);
		}

		public void TUpdate(CargoCompany entity)
		{
			_cargoCompanyDal.Update(entity);
		}
	}
}
