﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Domain.Entities
{
	public class Ordering
	{
		public int Id { get; set; }
		public string UserId { get; set; }
		public decimal TotalPrice { get; set; }
		public DateTime OrderDate { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }

	}
}
