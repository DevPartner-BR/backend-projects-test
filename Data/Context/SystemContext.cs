
namespace Data.Context
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Web;

    public class SystemContext : DbContext
    {

        public static SystemContext Create()
        {
            return new SystemContext();
        }


        protected override void OnModelCreating(DbModelBuilder m)
        {

            // Convencoes e Configuracoes
            // ------------------------------------------------------------------------------------------------
            m.Conventions.Remove<PluralizingTableNameConvention>();
            m.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            m.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            // Tabela Nota Fiscal
            // ------------------------------------------------------------------------------------------------
            m.Entity<NotaFiscal>().ToTable("NotaFiscal");

            
            m.Entity<NotaFiscal>().Property(p => p.Id).IsRequired();
            m.Entity<NotaFiscal>().Property(p => p.NumeroNf).IsRequired();
            m.Entity<NotaFiscal>().Property(p => p.DataNf).IsRequired();
            m.Entity<NotaFiscal>().Property(p => p.ValorTotal).IsRequired();
            m.Entity<NotaFiscal>().Property(p => p.CnpjEmissorNf).IsRequired().IsUnicode(false).HasMaxLength(14);
            m.Entity<NotaFiscal>().Property(p => p.CnpjDestinatarioNf).IsRequired().IsUnicode(false).HasMaxLength(14);

            m.Entity<NotaFiscal>().HasKey(k => k.Id);
            m.Entity<NotaFiscal>().HasIndex(i => i.NumeroNf).IsUnique(true).HasName("AK_NotaFiscal_NumeroNf");

            base.OnModelCreating(m);
        }

    }
}
