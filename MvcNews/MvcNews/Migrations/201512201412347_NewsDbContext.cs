namespace MvcNews.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsDbContext : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.News", "Category_Id", "dbo.Category");
            DropIndex("dbo.News", new[] { "Category_Id" });
            RenameColumn(table: "dbo.News", name: "Category_Id", newName: "CategoryID");
            AlterColumn("dbo.News", "CategoryID", c => c.Int(nullable: false));
            CreateIndex("dbo.News", "CategoryID");
            AddForeignKey("dbo.News", "CategoryID", "dbo.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.News", "CategoryID", "dbo.Category");
            DropIndex("dbo.News", new[] { "CategoryID" });
            AlterColumn("dbo.News", "CategoryID", c => c.Int());
            RenameColumn(table: "dbo.News", name: "CategoryID", newName: "Category_Id");
            CreateIndex("dbo.News", "Category_Id");
            AddForeignKey("dbo.News", "Category_Id", "dbo.Category", "Id");
        }
    }
}
