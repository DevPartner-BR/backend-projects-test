using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntitiesConfig
{
    public class NotaFiscalConfig : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalConfig()
        {
            //ToTable("NotasFiscais");

            HasKey(c => c.Id)
                .Property(c => c.Id);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.ValorTotal)
                .IsRequired();

            Property(c => c.Data)
                .IsRequired();

            Property(c => c.CNPJEmissor)
                .IsRequired()
                .HasMaxLength(30);

            Property(c => c.CNPJDestinatario)
                .IsRequired()
                .HasMaxLength(30);
        }

    }
}
