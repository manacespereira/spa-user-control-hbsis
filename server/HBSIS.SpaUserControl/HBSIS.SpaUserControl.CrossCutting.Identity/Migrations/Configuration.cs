using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using Microsoft.AspNet.Identity;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HBSIS.SpaUserControl.CrossCutting.Identity.Context.SpaIdentityContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HBSIS.SpaUserControl.CrossCutting.Identity.Context.SpaIdentityContext context)
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

            context.Users.AddOrUpdate(
                x => x.Id,
                new User { UserName = "manaces.ti@gmail.com", Email = "manaces.ti@gmail.com", EmailConfirmed = true, PasswordHash = new PasswordHasher().HashPassword("123456"), PhoneNumber = "11946493441", Active = true }
            );
        }
    }
}
