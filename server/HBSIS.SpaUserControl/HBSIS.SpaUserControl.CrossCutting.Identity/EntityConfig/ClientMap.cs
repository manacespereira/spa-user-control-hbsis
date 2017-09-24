using System.Data.Entity.ModelConfiguration;
using HBSIS.SpaUserControl.CrossCutting.Identity.Entities;

namespace HBSIS.SpaUserControl.CrossCutting.Identity.EntityConfig
{
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            ToTable("Clients");

            HasKey(uc => new { uc.UserId, uc.ClientId });

            Property(uc => uc.UserId).HasMaxLength(128).HasColumnName("UserId");
        }
    }
}
