namespace MvcNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class comment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                        Text = c.String(nullable: false),
                        News_Id = c.Int(),
                        NewsTag_TagId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.News", t => t.News_Id)
                .ForeignKey("dbo.NewsTag", t => t.NewsTag_TagId)
                .Index(t => t.News_Id)
                .Index(t => t.NewsTag_TagId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "NewsTag_TagId", "dbo.NewsTag");
            DropForeignKey("dbo.Comment", "News_Id", "dbo.News");
            DropIndex("dbo.Comment", new[] { "NewsTag_TagId" });
            DropIndex("dbo.Comment", new[] { "News_Id" });
            DropTable("dbo.Comment");
        }
    }
}
