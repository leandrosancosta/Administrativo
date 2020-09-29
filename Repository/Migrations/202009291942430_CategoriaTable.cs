namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriaTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cobrancas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Despesas", "CobrancaId");
            CreateIndex("dbo.Despesas", "CategoriaId");
            AddForeignKey("dbo.Despesas", "CategoriaId", "dbo.Categorias", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Despesas", "CobrancaId", "dbo.Cobrancas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Despesas", "CobrancaId", "dbo.Cobrancas");
            DropForeignKey("dbo.Despesas", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Despesas", new[] { "CategoriaId" });
            DropIndex("dbo.Despesas", new[] { "CobrancaId" });
            DropTable("dbo.Cobrancas");
            DropTable("dbo.Categorias");
        }
    }
}
