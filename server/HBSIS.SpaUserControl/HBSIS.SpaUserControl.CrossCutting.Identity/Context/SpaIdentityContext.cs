using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;
using HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.Context
{
    public class SpaIdentityContext : IdentityDbContext<Entities.User>, IDisposable
    {
        public SpaIdentityContext()
             : base(nameof(SpaIdentityContext), throwIfV1Schema: false)
        {
            Database.SetInitializer<SpaIdentityContext>(null);
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }
        public static SpaIdentityContext Create()
        {
            return new SpaIdentityContext();
        }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            modelBuilder.Configurations.Add(new RoleMap());
            modelBuilder.Configurations.Add(new UserMap());
            modelBuilder.Configurations.Add(new LoginMap());
            modelBuilder.Configurations.Add(new ClaimMap());
            modelBuilder.Configurations.Add(new ClientMap());
            modelBuilder.Configurations.Add(new UserRoleMap());
            modelBuilder.Configurations.Add(new UserClaimMap());


        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreatedAt") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CreatedAt").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
