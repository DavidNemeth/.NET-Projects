namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnnotation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kliens", "Surgos", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kliens", "Surgos");
        }
    }
}
