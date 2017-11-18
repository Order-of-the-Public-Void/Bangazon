namespace Bangazon.Migrations
{
    using Bangazon.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bangazon.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bangazon.Models.ApplicationDbContext context)
        {

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            //var adminRole = IdentityRole("Admin");
            //context.Roles.AddOrUpdate(ref => r.Name, adminRole);
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var user = new ApplicationUser
            {
                UserName = "tasha",
                Email = "tasha@aol.com",
            };

            userManager.CreateAsync(user, "password").Wait();
            //var addedUser = context.Users.First(x => x.UserName == user.UserName);
            //ApplicationUserManager.AddRoleAsync(addedUser.Id, "Admin").Wait();
        }
    }
}
