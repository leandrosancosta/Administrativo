namespace Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoryTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categoria",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 1000, unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                        UserId = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Email = c.String(maxLength: 1000, unicode: false),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(maxLength: 1000, unicode: false),
                        SecurityStamp = c.String(maxLength: 1000, unicode: false),
                        PhoneNumber = c.String(maxLength: 1000, unicode: false),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 1000, unicode: false),
                        ClaimType = c.String(maxLength: 1000, unicode: false),
                        ClaimValue = c.String(maxLength: 1000, unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        LoginProvider = c.String(maxLength: 1000, unicode: false),
                        ProviderKey = c.String(maxLength: 1000, unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128, unicode: false),
                        UserId = c.String(nullable: false, maxLength: 128, unicode: false),
                        ApplicationUser_Id = c.String(maxLength: 128, unicode: false),
                        IdentityRole_Id = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Cobranca",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DtFechamentoFatura = c.Int(nullable: false),
                        DtVencimentoFatura = c.Int(nullable: false),
                        TipoCobranca = c.String(maxLength: 1000, unicode: false),
                        Nome = c.String(maxLength: 1000, unicode: false),
                        Status = c.Int(nullable: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                        UserId = c.String(maxLength: 128, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Despesa",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false, precision: 0),
                        Descricao = c.String(maxLength: 1000, unicode: false),
                        Valor = c.Double(nullable: false),
                        CobrancaId = c.Int(nullable: false),
                        Parcelamento = c.String(maxLength: 1000, unicode: false),
                        CategoriaId = c.Int(nullable: false),
                        Observacao = c.String(maxLength: 1000, unicode: false),
                        Create = c.DateTime(nullable: false, precision: 0),
                        Modified = c.DateTime(nullable: false, precision: 0),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categoria", t => t.CategoriaId, cascadeDelete: true)
                .ForeignKey("dbo.Cobranca", t => t.CobrancaId, cascadeDelete: true)
                .Index(t => t.CobrancaId)
                .Index(t => t.CategoriaId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128, unicode: false),
                        Name = c.String(maxLength: 1000, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Cobranca", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Despesa", "CobrancaId", "dbo.Cobranca");
            DropForeignKey("dbo.Despesa", "CategoriaId", "dbo.Categoria");
            DropForeignKey("dbo.Categoria", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropIndex("dbo.Despesa", new[] { "CategoriaId" });
            DropIndex("dbo.Despesa", new[] { "CobrancaId" });
            DropIndex("dbo.Cobranca", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Categoria", new[] { "UserId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Despesa");
            DropTable("dbo.Cobranca");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Categoria");
        }
    }
}
