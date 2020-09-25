namespace WApp.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoriaTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categoria", "Nome", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Cobranca", "Nome", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.Situacao", "Nome", c => c.String(nullable: false, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Situacao", "Nome", c => c.String(unicode: false));
            AlterColumn("dbo.Cobranca", "Nome", c => c.String(unicode: false));
            AlterColumn("dbo.Categoria", "Nome", c => c.String(unicode: false));
        }
    }
}
