﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Application.Interfaces
{
	public interface IRepository<T> where T: class
	{
		Task<T> GetByIdAsync(int id);
		Task<List<T>> GetAllAsync();
		Task AddAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
		Task<List<T>> GetbyFilterAsync(Expression<Func<T, bool>> filter);
	}
}
