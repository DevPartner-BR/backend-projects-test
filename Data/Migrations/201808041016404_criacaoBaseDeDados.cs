namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class criacaoBaseDeDados : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tb_NotasFiscais",
                c => new
                    {
                        NotaFiscalId = c.Int(nullable: false, identity: true),
                        NumeroNF = c.String(nullable: false, maxLength: 50),
                        ValorTotalNF = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataNF = c.DateTime(nullable: false),
                        CNPJEmissorNF = c.String(nullable: false, maxLength: 30),
                        CNPJDestinatarioNF = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.NotaFiscalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tb_NotasFiscais");
        }
    }
}
