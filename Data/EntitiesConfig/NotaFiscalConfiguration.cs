using Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntitiesConfig
{
    public class NotaFiscalConfiguration : EntityTypeConfiguration<NotaFiscal>
    {
        public NotaFiscalConfiguration()
        {
            ToTable("Tb_NotasFiscais");

            HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasColumnName("NotaFiscalId");

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("NumeroNF");

            Property(c => c.ValorTotal)
                .IsRequired()
                .HasColumnName("ValorTotalNF");

            Property(c => c.Data)
                .IsRequired()
                .HasColumnName("DataNF");

            Property(c => c.CNPJEmissor)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("CNPJEmissorNF");

            Property(c => c.CNPJDestinatario)
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnName("CNPJDestinatarioNF");
        }
    }
}