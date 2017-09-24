using System.Data.Entity.ModelConfiguration;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class UserMap : EntityTypeConfiguration<User>
    {
        public UserMap()
        {
            ToTable("Users");

            HasKey(x => x.Id);

            HasMany(u => u.Roles)
                .WithRequired()
                .HasForeignKey(ur => ur.UserId);

            HasMany(u => u.Claims)
                .WithRequired()
                .HasForeignKey(uc => uc.UserId);

            HasMany(u => u.Logins)
                .WithRequired()
                .HasForeignKey(ul => ul.UserId);

            Property(u => u.Id).HasColumnName("UserId");
            Property(u => u.CreatedAt).HasColumnType("datetime2").HasPrecision(0);
        }
    }
}
