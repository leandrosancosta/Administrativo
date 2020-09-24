namespace WApp.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinanceiroTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.Despesa",
                c => new
                    {
                        DespesaId = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Descricao = c.String(unicode: false),
                        Valor = c.Double(nullable: false),
                        CobrancaId = c.Int(nullable: false),
                        Parcelamento = c.String(unicode: false),
                        CategoriaId = c.Int(nullable: false),
                        Observacao = c.String(unicode: false),
                        SituacaoId = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.DespesaId)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Cobranca", t => t.CobrancaId, cascadeDelete: true)
                .ForeignKey("dbo.Situacao", t => t.SituacaoId, cascadeDelete: true)
                .Index(t => t.CobrancaId)
                .Index(t => t.CategoriaId)
                .Index(t => t.SituacaoId);
            
            CreateTable(
                "dbo.Cobranca",
                c => new
                    {
                        CobrancaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.CobrancaId);
            
            CreateTable(
                "dbo.Situacao",
                c => new
                    {
                        SituacaoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.SituacaoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Despesa", "SituacaoId", "dbo.Situacao");
            DropForeignKey("dbo.Despesa", "CobrancaId", "dbo.Cobranca");
            DropForeignKey("dbo.Despesa", "CategoriaId", "dbo.Categoria");
            DropIndex("dbo.Despesa", new[] { "SituacaoId" });
            DropIndex("dbo.Despesa", new[] { "CategoriaId" });
            DropIndex("dbo.Despesa", new[] { "CobrancaId" });
            DropTable("dbo.Situacao");
            DropTable("dbo.Cobranca");
            DropTable("dbo.Despesa");
            DropTable("dbo.Categoria");
        }
    }
}
