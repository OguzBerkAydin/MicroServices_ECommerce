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
	public class CargoDetailManager : ICargoDetailService
	{
		private readonly ICargoDetailDal _cargoDetailDal;

		public CargoDetailManager(ICargoDetailDal cargoDetailDal)
		{
			_cargoDetailDal = cargoDetailDal;
		}

		public void TAdd(CargoDetail entity)
		{
			_cargoDetailDal.Add(entity);
		}

		public void TDelete(int id)
		{
			_cargoDetailDal.Delete(id);
		}

		public List<CargoDetail> TGetAll()
		{
			return _cargoDetailDal.GetAll();
		}

		public CargoDetail TGetById(int id)
		{
			return _cargoDetailDal.GetById(id);
		}

		public void TUpdate(CargoDetail entity)
		{
			_cargoDetailDal.Update(entity);
		}
	}
}
