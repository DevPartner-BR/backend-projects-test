namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NotaFiscal",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.String(nullable: false, maxLength: 50, unicode: false),
                        ValorTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Data = c.DateTime(nullable: false),
                        CNPJEmissor = c.String(nullable: false, maxLength: 30, unicode: false),
                        CNPJDestinatario = c.String(nullable: false, maxLength: 30, unicode: false),
                        DataCadastro = c.DateTime(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.NotaFiscal");
        }
    }
}
