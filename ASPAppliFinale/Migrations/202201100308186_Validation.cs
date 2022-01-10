namespace ASPAppliFinale.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Validation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TProprio", "PMail", c => c.String(nullable: false));
            AlterColumn("dbo.TProprio", "PMdp", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TProprio", "PMdp", c => c.String());
            AlterColumn("dbo.TProprio", "PMail", c => c.String());
        }
    }
}
