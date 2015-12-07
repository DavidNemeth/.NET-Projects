namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogListViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Description = c.String(),
                        Body = c.String(),
                        UrlOpt = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Category", "BlogListViewModel_Id", c => c.Int());
            AddColumn("dbo.Tag", "BlogListViewModel_Id", c => c.Int());
            CreateIndex("dbo.Category", "BlogListViewModel_Id");
            CreateIndex("dbo.Tag", "BlogListViewModel_Id");
            AddForeignKey("dbo.Category", "BlogListViewModel_Id", "dbo.BlogListViewModel", "Id");
            AddForeignKey("dbo.Tag", "BlogListViewModel_Id", "dbo.BlogListViewModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "BlogListViewModel_Id", "dbo.BlogListViewModel");
            DropForeignKey("dbo.Category", "BlogListViewModel_Id", "dbo.BlogListViewModel");
            DropIndex("dbo.Tag", new[] { "BlogListViewModel_Id" });
            DropIndex("dbo.Category", new[] { "BlogListViewModel_Id" });
            DropColumn("dbo.Tag", "BlogListViewModel_Id");
            DropColumn("dbo.Category", "BlogListViewModel_Id");
            DropTable("dbo.BlogListViewModel");
        }
    }
}
