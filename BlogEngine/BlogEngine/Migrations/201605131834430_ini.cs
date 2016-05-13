namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ini : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Category", "EditPostViewModel_Id", "dbo.EditPostViewModel");
            DropForeignKey("dbo.EditPostViewModel", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Tag", "EditPostViewModel_Id", "dbo.EditPostViewModel");
            DropIndex("dbo.Category", new[] { "EditPostViewModel_Id" });
            DropIndex("dbo.Tag", new[] { "EditPostViewModel_Id" });
            DropIndex("dbo.EditPostViewModel", new[] { "Post_Id" });
            DropColumn("dbo.Category", "EditPostViewModel_Id");
            DropColumn("dbo.Tag", "EditPostViewModel_Id");
            DropTable("dbo.EditPostViewModel");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EditPostViewModel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Description = c.String(),
                        Body = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tag", "EditPostViewModel_Id", c => c.Int());
            AddColumn("dbo.Category", "EditPostViewModel_Id", c => c.Int());
            CreateIndex("dbo.EditPostViewModel", "Post_Id");
            CreateIndex("dbo.Tag", "EditPostViewModel_Id");
            CreateIndex("dbo.Category", "EditPostViewModel_Id");
            AddForeignKey("dbo.Tag", "EditPostViewModel_Id", "dbo.EditPostViewModel", "Id");
            AddForeignKey("dbo.EditPostViewModel", "Post_Id", "dbo.Post", "Id");
            AddForeignKey("dbo.Category", "EditPostViewModel_Id", "dbo.EditPostViewModel", "Id");
        }
    }
}
