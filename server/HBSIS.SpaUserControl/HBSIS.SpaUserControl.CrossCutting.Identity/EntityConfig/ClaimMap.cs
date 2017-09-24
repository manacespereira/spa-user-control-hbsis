using System.Data.Entity.ModelConfiguration;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class ClaimMap : EntityTypeConfiguration<Claim>
    {
        public ClaimMap()
        {
            ToTable("Claims");

            HasKey(c => c.ClaimId);

            Property(c => c.Name).HasMaxLength(128);
            Property(c => c.Type).HasMaxLength(128);
            Property(c => c.Value).HasMaxLength(128);
        }
    }
}
