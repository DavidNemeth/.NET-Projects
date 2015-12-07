namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogListViewModel", "Post_Id", c => c.Int());
            CreateIndex("dbo.BlogListViewModel", "Post_Id");
            AddForeignKey("dbo.BlogListViewModel", "Post_Id", "dbo.Post", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BlogListViewModel", "Post_Id", "dbo.Post");
            DropIndex("dbo.BlogListViewModel", new[] { "Post_Id" });
            DropColumn("dbo.BlogListViewModel", "Post_Id");
        }
    }
}
