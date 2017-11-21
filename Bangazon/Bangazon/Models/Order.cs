using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class Order
    {
		[Key]
		public int OrderId { get; set; }
        public virtual List<User> Users { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderStatus { get; set; }
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public int ShippingZip { get; set; }

    }
}