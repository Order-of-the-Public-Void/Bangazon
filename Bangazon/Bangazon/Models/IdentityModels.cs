using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Bangazon.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
		public string FName { get; set; }
		public string LName { get; set; }
		public string City { get; set; }
		public string Street { get; set; }
		public string State { get; set; }
		public int Zip { get; set; }
		public virtual List<Product> Products { get; set; }
		public virtual List<Recommendation> Recommendations { get; set; }
	}

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
		public System.Data.Entity.DbSet<Bangazon.Models.LineItem> LineItems { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Order> Orders { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.PaymentMethod> PaymentMethods { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Product> Products { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.ProductCategory> ProductCategories { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.ProductImage> ProductImages { get; set; }

		public System.Data.Entity.DbSet<Bangazon.Models.Recommendation> Recommendations { get; set; }

	}
}