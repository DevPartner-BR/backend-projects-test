namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaNotaFiscal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        NumeroNf = c.Int(nullable: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataNf = c.DateTime(nullable: false),
                        CnpjEmissorNf = c.String(nullable: false, maxLength: 14, unicode: false),
                        CnpjDestinatarioNf = c.String(nullable: false, maxLength: 14, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NumeroNf, unique: true, name: "AK_NotaFiscal_NumeroNf");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.NotaFiscal", "AK_NotaFiscal_NumeroNf");
            DropTable("dbo.NotaFiscal");
        }
    }
}
