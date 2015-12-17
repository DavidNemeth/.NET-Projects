namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.Post_Id)
                .Index(t => t.Post_Id);
            
            AddColumn("dbo.Category", "EditPostViewModel_Id", c => c.Int());
            AddColumn("dbo.Tag", "EditPostViewModel_Id", c => c.Int());
            CreateIndex("dbo.Category", "EditPostViewModel_Id");
            CreateIndex("dbo.Tag", "EditPostViewModel_Id");
            AddForeignKey("dbo.Category", "EditPostViewModel_Id", "dbo.EditPostViewModel", "Id");
            AddForeignKey("dbo.Tag", "EditPostViewModel_Id", "dbo.EditPostViewModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tag", "EditPostViewModel_Id", "dbo.EditPostViewModel");
            DropForeignKey("dbo.EditPostViewModel", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.Category", "EditPostViewModel_Id", "dbo.EditPostViewModel");
            DropIndex("dbo.EditPostViewModel", new[] { "Post_Id" });
            DropIndex("dbo.Tag", new[] { "EditPostViewModel_Id" });
            DropIndex("dbo.Category", new[] { "EditPostViewModel_Id" });
            DropColumn("dbo.Tag", "EditPostViewModel_Id");
            DropColumn("dbo.Category", "EditPostViewModel_Id");
            DropTable("dbo.EditPostViewModel");
        }
    }
}
