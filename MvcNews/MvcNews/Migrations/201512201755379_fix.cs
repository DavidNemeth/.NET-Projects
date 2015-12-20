namespace MvcNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comment", "News_Id", "dbo.News");
            DropIndex("dbo.Comment", new[] { "News_Id" });
            RenameColumn(table: "dbo.Comment", name: "News_Id", newName: "NewsID");
            AlterColumn("dbo.Comment", "NewsID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comment", "NewsID");
            AddForeignKey("dbo.Comment", "NewsID", "dbo.News", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comment", "NewsID", "dbo.News");
            DropIndex("dbo.Comment", new[] { "NewsID" });
            AlterColumn("dbo.Comment", "NewsID", c => c.Int());
            RenameColumn(table: "dbo.Comment", name: "NewsID", newName: "News_Id");
            CreateIndex("dbo.Comment", "News_Id");
            AddForeignKey("dbo.Comment", "News_Id", "dbo.News", "Id");
        }
    }
}
