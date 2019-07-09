namespace Data.Context
{
    using Data.EntitiesConfig;
    using Domain.Entities;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SystemContext : DbContext
    {
        public SystemContext() : base("DefaultConnection")
        {
        }

        public static SystemContext Create()
        {
            return new SystemContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new NotaFiscalConfiguration());
        }

        public DbSet<NotaFiscal> NotasFiscais { get; set; }
    }
}