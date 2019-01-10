
namespace Data.Context
{
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Web;

    public class SystemContext : DbContext
    {

        #region Construtores

        /// <summary>
        /// Cria uma nova instância de SystemContext
        /// </summary>
        /// <param name="nameOrConnectionString">Nome da configuração de string de conexão ou string de conexão</param>
        public SystemContext(string nameOrConnectionString) : base(nameOrConnectionString) { }

        /// <summary>
        /// Cria uma nova instância de SystemContext
        /// </summary>
        public SystemContext() : this("DevPartnerDb") { }

        #endregion

        #region Métodos Estáticos

        /// <summary>
        /// Cria uma nova instância de SystemContext
        /// </summary>
        /// <returns>Uma nova instãncia do objeto</returns>
        public static SystemContext Create()
        {
            return new SystemContext();
        }

        #endregion


        #region Overrides

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

            m.Entity<NotaFiscal>().Ignore(c => c.ValidationResult);
            m.Entity<NotaFiscal>().Ignore(c => c.CascadeMode);

            base.OnModelCreating(m);
        }

        #endregion

        #region DbSets

        public virtual DbSet NotaFiscal { get; set; }

        #endregion

    }

}
