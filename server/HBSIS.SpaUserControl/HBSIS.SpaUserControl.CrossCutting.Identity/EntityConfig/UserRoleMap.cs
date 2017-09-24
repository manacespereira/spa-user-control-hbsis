using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class UserRoleMap : EntityTypeConfiguration<IdentityUserRole>
    {
        public UserRoleMap()
        {
            ToTable("UserRoles");

            HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}
