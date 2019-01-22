
namespace Data.Context
{
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


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();


            base.OnModelCreating(modelBuilder);
        }

    }
}
