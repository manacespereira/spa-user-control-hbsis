using System.Data.Entity.ModelConfiguration;
using HBSIS.SpaUserControl.Domain.Models;

namespace HBSIS.SpaUserControl.Data.Mappings
{    
    public class ClientMap : EntityTypeConfiguration<Client>
    {
        public ClientMap()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .HasMaxLength(100)
                .IsRequired();

            Property(c => c.Email)
                .HasMaxLength(100)
                .IsRequired();

            Property(x => x.DocumentNumber)
                .IsRequired()
                .HasMaxLength(14);

            Property(x => x.PhoneNumber)
                .IsRequired()
                .HasMaxLength(11);
        }
    }
}