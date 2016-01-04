namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kliens",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vezetéknév = c.String(),
                        Keresztnév = c.String(),
                        Szulido = c.DateTime(),
                        SzereloID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Szerelo", t => t.SzereloID, cascadeDelete: true)
                .Index(t => t.SzereloID);
            
            CreateTable(
                "dbo.Szerelo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Vezetéknév = c.String(),
                        Keresztnév = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Kliens", "SzereloID", "dbo.Szerelo");
            DropIndex("dbo.Kliens", new[] { "SzereloID" });
            DropTable("dbo.Szerelo");
            DropTable("dbo.Kliens");
        }
    }
}
