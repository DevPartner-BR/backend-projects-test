
namespace Data.Context
{
    using Domain.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SystemContext : DbContext
    {
        public SystemContext() : base("DevPartner")
        {

        }

        public static SystemContext Create()
        {
            return new SystemContext();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<NotaFiscal> NotaFiscal { get; set; }

    }
}
