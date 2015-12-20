namespace MvcNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Published = c.Boolean(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.CategoryID, cascadeDelete: true)
                .Index(t => t.CategoryID);
            
            CreateTable(
                "dbo.NewsTag",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                        TagName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.NewsTagNews",
                c => new
                    {
                        NewsTag_TagId = c.Int(nullable: false),
                        News_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NewsTag_TagId, t.News_Id })
                .ForeignKey("dbo.NewsTag", t => t.NewsTag_TagId, cascadeDelete: true)
                .ForeignKey("dbo.News", t => t.News_Id, cascadeDelete: true)
                .Index(t => t.NewsTag_TagId)
                .Index(t => t.News_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NewsTagNews", "News_Id", "dbo.News");
            DropForeignKey("dbo.NewsTagNews", "NewsTag_TagId", "dbo.NewsTag");
            DropForeignKey("dbo.News", "CategoryID", "dbo.Category");
            DropIndex("dbo.NewsTagNews", new[] { "News_Id" });
            DropIndex("dbo.NewsTagNews", new[] { "NewsTag_TagId" });
            DropIndex("dbo.News", new[] { "CategoryID" });
            DropTable("dbo.NewsTagNews");
            DropTable("dbo.NewsTag");
            DropTable("dbo.News");
            DropTable("dbo.Category");
        }
    }
}
