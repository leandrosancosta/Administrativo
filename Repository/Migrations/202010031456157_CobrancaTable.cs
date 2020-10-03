namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class CobrancaTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cobrancas", "DtFechamentoFatura", c => c.Int(nullable: true));
            AddColumn("dbo.Cobrancas", "DtVencimentoFatura", c => c.Int(nullable: true));
            AddColumn("dbo.Cobrancas", "TipoCobranca", c => c.String(unicode: true, nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Cobrancas", "TipoCobranca");
            DropColumn("dbo.Cobrancas", "DtVencimentoFatura");
            DropColumn("dbo.Cobrancas", "DtFechamentoFatura");
        }
    }
}
