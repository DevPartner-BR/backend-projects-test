namespace Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.SystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Data.Context.SystemContext context)
        {
            //context.Authors.AddOrUpdate(x => x.Id,
            //   new Author() { Id = 1, Name = "Jane Austen" },
            //   new Author() { Id = 2, Name = "Charles Dickens" },
            //   new Author() { Id = 3, Name = "Miguel de Cervantes" }
            //   );
        }
    }
}
