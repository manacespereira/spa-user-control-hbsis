using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class RoleMap : EntityTypeConfiguration<IdentityRole>
    {
        public RoleMap()
        {
            ToTable("Roles");

            HasKey(r => r.Id);

            Property(r => r.Id).HasColumnName("RoleId");

            HasMany(r => r.Users).WithRequired().HasForeignKey(ur => ur.RoleId);
        }
    }
}
