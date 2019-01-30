
namespace Data.Context
{
    using Data.EntitiesConfig;
    using Domain.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Web;

    public class SystemContext : DbContext
    {
        public SystemContext() : base("DevPartnerDataBase")
        {

        }
        public static SystemContext Create()
        {
            return new SystemContext();
        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //toda propriedade que tiver Id no final será uma primary key
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            //altera toda propriedade que for string para varchar no banco de dados
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //por padrão toda propriedade string terá um tamanho de 100 caracteres
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new NotaFiscalConfig());

            base.OnModelCreating(modelBuilder);
        }

    }
}
