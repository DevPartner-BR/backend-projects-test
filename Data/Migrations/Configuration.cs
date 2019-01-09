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
            // Alterado para autom�tico por ser uma quest�o de teste
            // N�o deve ser usado em um cen�rio real (ambiente produtivo)
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.Context.SystemContext context)
        {

        }
    }
}
