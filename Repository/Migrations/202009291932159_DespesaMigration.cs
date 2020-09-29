namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DespesaMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Despesas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Descricao = c.String(unicode: false),
                        Valor = c.Double(nullable: false),
                        CobrancaId = c.Int(nullable: false),
                        Parcelamento = c.String(unicode: false),
                        CategoriaId = c.Int(nullable: false),
                        Observacao = c.String(unicode: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Despesas");
        }
    }
}
