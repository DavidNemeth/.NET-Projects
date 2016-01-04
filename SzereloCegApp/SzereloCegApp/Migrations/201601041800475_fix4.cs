namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Szerelo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vezetéknév = c.String(nullable: false),
                        Keresztnév = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Ugyfel",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vezetéknév = c.String(nullable: false),
                        Keresztnév = c.String(nullable: false),
                        Szulido = c.DateTime(),
                        FelvetelIdeje = c.DateTime(nullable: false),
                        Surgos = c.Boolean(nullable: false),
                        SzereloID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Szerelo", t => t.SzereloID, cascadeDelete: true)
                .Index(t => t.SzereloID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ugyfel", "SzereloID", "dbo.Szerelo");
            DropIndex("dbo.Ugyfel", new[] { "SzereloID" });
            DropTable("dbo.Ugyfel");
            DropTable("dbo.Szerelo");
        }
    }
}
