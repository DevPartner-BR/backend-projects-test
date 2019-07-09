namespace WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaFiscals",
                c => new
                    {
                        NotaFiscalId = c.Int(nullable: false, identity: true),
                        NumeroNF = c.String(),
                        ValorTotal = c.Double(nullable: false),
                        DataNF = c.DateTime(nullable: false),
                        CNPJEmissorNF = c.String(),
                        CNPJDestinatarioNF = c.String(),
                    })
                .PrimaryKey(t => t.NotaFiscalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotaFiscals");
        }
    }
}
