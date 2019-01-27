
namespace Data.Context
    {
    using Data.EntitiesConfig;
    using Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;

    public class SystemContext : DbContext
        {

        public static SystemContext Create()
            {
            return new SystemContext();
            }


        public SystemContext() : base("name=ConnectionString")
        {
            
            Database.SetInitializer<SystemContext>(new CreateDatabaseIfNotExists<SystemContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SystemContext, Configuration>(useSuppliedContext: true));
            }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));

            modelBuilder.Configurations.Add(new NotaFiscalConfiguration());

            base.OnModelCreating(modelBuilder);
            }

        }
    }
