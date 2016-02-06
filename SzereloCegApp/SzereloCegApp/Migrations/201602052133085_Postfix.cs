namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Postfix : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Post", new[] { "Szerelo_ID" });
            RenameColumn(table: "dbo.Post", name: "Szerelo_ID", newName: "SzereloID");
            AlterColumn("dbo.Post", "SzereloID", c => c.Int(nullable: false));
            CreateIndex("dbo.Post", "SzereloID");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Post", new[] { "SzereloID" });
            AlterColumn("dbo.Post", "SzereloID", c => c.Int());
            RenameColumn(table: "dbo.Post", name: "SzereloID", newName: "Szerelo_ID");
            CreateIndex("dbo.Post", "Szerelo_ID");
        }
    }
}
