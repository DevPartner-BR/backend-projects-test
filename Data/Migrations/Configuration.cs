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
            // Alterado para automático por ser uma questão de teste
            // Não deve ser usado em um cenário real (ambiente produtivo)
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Data.Context.SystemContext context)
        {

        }
    }
}
