namespace MvcNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class commentfix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "NewsTag_TagId", "dbo.NewsTag");
            DropIndex("dbo.Comment", new[] { "NewsTag_TagId" });
            DropColumn("dbo.Comment", "NewsTag_TagId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comment", "NewsTag_TagId", c => c.Int());
            CreateIndex("dbo.Comment", "NewsTag_TagId");
            AddForeignKey("dbo.Comment", "NewsTag_TagId", "dbo.NewsTag", "TagId");
        }
    }
}
