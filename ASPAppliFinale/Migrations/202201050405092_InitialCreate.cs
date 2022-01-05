namespace ASPAppliFinale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TAnnonce",
                c => new
                    {
                        IDAnnonce = c.Int(nullable: false, identity: true),
                        IDProprio = c.Int(nullable: false),
                        IDModel = c.Int(nullable: false),
                        AAnnee = c.String(),
                        AKilometrage = c.String(),
                        ACouleur = c.String(),
                        APrix = c.Single(nullable: false),
                        AStatut = c.String(),
                    })
                .PrimaryKey(t => t.IDAnnonce)
                .ForeignKey("dbo.TModel", t => t.IDModel, cascadeDelete: true)
                .ForeignKey("dbo.TProprio", t => t.IDProprio, cascadeDelete: true)
                .Index(t => t.IDProprio)
                .Index(t => t.IDModel);
            
            CreateTable(
                "dbo.TModel",
                c => new
                    {
                        IDModel = c.Int(nullable: false, identity: true),
                        IDMarque = c.Int(nullable: false),
                        MNom = c.String(),
                    })
                .PrimaryKey(t => t.IDModel)
                .ForeignKey("dbo.TMarque", t => t.IDMarque, cascadeDelete: true)
                .Index(t => t.IDMarque);
            
            CreateTable(
                "dbo.TMarque",
                c => new
                    {
                        IDMarque = c.Int(nullable: false, identity: true),
                        MNom = c.String(),
                    })
                .PrimaryKey(t => t.IDMarque);
            
            CreateTable(
                "dbo.TProprio",
                c => new
                    {
                        IDProprio = c.Int(nullable: false, identity: true),
                        PNom = c.String(),
                        PPrenom = c.String(),
                        PNumTel = c.String(),
                        PMail = c.String(),
                        PMdp = c.String(),
                    })
                .PrimaryKey(t => t.IDProprio);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TAnnonce", "IDProprio", "dbo.TProprio");
            DropForeignKey("dbo.TAnnonce", "IDModel", "dbo.TModel");
            DropForeignKey("dbo.TModel", "IDMarque", "dbo.TMarque");
            DropIndex("dbo.TModel", new[] { "IDMarque" });
            DropIndex("dbo.TAnnonce", new[] { "IDModel" });
            DropIndex("dbo.TAnnonce", new[] { "IDProprio" });
            DropTable("dbo.TProprio");
            DropTable("dbo.TMarque");
            DropTable("dbo.TModel");
            DropTable("dbo.TAnnonce");
        }
    }
}
