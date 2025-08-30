namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebAPI.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebAPI.Models.WebAPIContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebAPI.Models.WebAPIContext context)
        {
            context.NotaFiscals.AddOrUpdate(x => x.NotaFiscalId,
                 new NotaFiscal() { NotaFiscalId = 1, CNPJDestinatarioNF = "57.877.625/0001-53", CNPJEmissorNF = "21.709.451/0001-72", DataNF = DateTime.Now, NumeroNF = "1000", ValorTotal = 2500.45 },
                 new NotaFiscal() { NotaFiscalId = 2, CNPJDestinatarioNF = "48.792.344/0001-07", CNPJEmissorNF = "17.710.632/0001-41", DataNF = DateTime.Now, NumeroNF = "2000", ValorTotal = 7500.22 },
                 new NotaFiscal() { NotaFiscalId = 3, CNPJDestinatarioNF = "24.886.518/0001-32", CNPJEmissorNF = "41.578.027/0001-43", DataNF = DateTime.Now, NumeroNF = "3000", ValorTotal = 1250.00 }
                 );
        }
    }
}
