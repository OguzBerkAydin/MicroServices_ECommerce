﻿using ECommerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Persistence.Context
{
	public class OrderContext : DbContext
	{
		public OrderContext(DbContextOptions<OrderContext> options) : base(options)
		{
		}
		public DbSet<Address> Addresses{ get; set; }
		public DbSet<OrderDetail> OrderDetails{ get; set; }
		public DbSet<Ordering> Orderings{ get; set; }
	}
}
