﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class LineItem
    {
		[Key]
		public int LineItemId { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<Product> Products { get; set; }
        public int Quantity { get; set; }
        public decimal Rating { get; set; }
    }
}