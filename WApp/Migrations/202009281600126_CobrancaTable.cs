namespace WApp.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CobrancaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cobranca", "DataCobranca", c => c.DateTime(precision: 0));
            AddColumn("dbo.Cobranca", "DataFatura", c => c.DateTime(precision: 0));
            AddColumn("dbo.Cobranca", "TipoCobranca", c => c.Short(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cobranca", "TipoCobranca");
            DropColumn("dbo.Cobranca", "DataFatura");
            DropColumn("dbo.Cobranca", "DataCobranca");
        }
    }
}
