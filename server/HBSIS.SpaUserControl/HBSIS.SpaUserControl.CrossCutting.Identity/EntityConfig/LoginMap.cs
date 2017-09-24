using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class LoginMap : EntityTypeConfiguration<IdentityUserLogin>
    {
        public LoginMap()
        {
            ToTable("UserLogins");

            HasKey(l => new { l.UserId, l.LoginProvider, l.ProviderKey });
        }
    }
}
