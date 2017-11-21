using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WorkForce.Models
{
	public class AppDbContext : DbContext
	{
		// You can add custom code to this file. Changes will not be overwritten.
		// 
		// If you want Entity Framework to drop and regenerate your database
		// automatically whenever you change your model schema, please use data migrations.
		// For more information refer to the documentation:
		// http://msdn.microsoft.com/en-us/data/jj591621.aspx

		public AppDbContext() : base("name=BangazonFinal")
		{
		}

		public System.Data.Entity.DbSet<Bangazon.Models.LineItem> LineItems { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Order> Orders { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.PaymentMethod> PaymentMethods { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Product> Products { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.ProductCategory> ProductCategories { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.ProductImage> ProductImages { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Recommendation> Recommendations { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.User> Users { get; set; }
	}
}