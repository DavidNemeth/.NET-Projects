namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Post : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Szerelo_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Szerelo", t => t.Szerelo_ID)
                .Index(t => t.Szerelo_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Szerelo_ID", "dbo.Szerelo");
            DropIndex("dbo.Post", new[] { "Szerelo_ID" });
            DropTable("dbo.Post");
        }
    }
}
