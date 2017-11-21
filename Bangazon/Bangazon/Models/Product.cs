using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bangazon.Models
{
    public class Product
    {
		[Key]
		public int ProductId { get; set; }
        public virtual List<User> Users { get; set; }
        public virtual List<ProductCategory> ProductCategories { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
        public int NumberSold { get; set; }
        public decimal Price { get; set; }
        public decimal AvgCustomerRating { get; set; }
        public bool LocalDelivery { get; set; }
        public string DeliveryCity { get; set; }
        public decimal PossibilityCoefficient { get; set; }
    }
}