namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Criação_tabela_NotaFiscal : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        notaFiscalId = c.Int(nullable: false, identity: true),
                        numeroNf = c.String(maxLength: 8000, unicode: false),
                        valorTotal = c.Int(nullable: false),
                        dataNf = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        cnpjEmissorNf = c.String(maxLength: 8000, unicode: false),
                        cnpjDestinatarioNf = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.notaFiscalId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotaFiscal");
        }
    }
}
