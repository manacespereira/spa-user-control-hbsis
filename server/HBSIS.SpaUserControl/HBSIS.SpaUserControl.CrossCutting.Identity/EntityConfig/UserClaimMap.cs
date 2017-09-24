using System.Data.Entity.ModelConfiguration;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class UserClaimMap : EntityTypeConfiguration<IdentityUserClaim>
    {
        public UserClaimMap()
        {
            ToTable("UserClaims");

            HasKey(uc => new { uc.UserId, uc.Id });

            Property(x => x.Id).HasColumnName("ClaimId");
        }
    }
}
