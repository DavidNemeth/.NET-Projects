namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlOpt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Description = c.String(),
                        Body = c.String(),
                        Meta = c.String(),
                        UrlOpt = c.String(),
                        Published = c.Boolean(nullable: false),
                        PostedDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                        Category_Id = c.Int(),
                        Comment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Category", t => t.Category_Id)
                .ForeignKey("dbo.Comment", t => t.Comment_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Comment_Id);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UrlOpt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UrlOpt = c.String(),
                        Body = c.String(),
                        UserName = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TagPost",
                c => new
                    {
                        Tag_Id = c.Int(nullable: false),
                        Post_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Tag_Id, t.Post_Id })
                .ForeignKey("dbo.Tag", t => t.Tag_Id, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.Post_Id, cascadeDelete: true)
                .Index(t => t.Tag_Id)
                .Index(t => t.Post_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Post", "Comment_Id", "dbo.Comment");
            DropForeignKey("dbo.TagPost", "Post_Id", "dbo.Post");
            DropForeignKey("dbo.TagPost", "Tag_Id", "dbo.Tag");
            DropForeignKey("dbo.Post", "Category_Id", "dbo.Category");
            DropIndex("dbo.TagPost", new[] { "Post_Id" });
            DropIndex("dbo.TagPost", new[] { "Tag_Id" });
            DropIndex("dbo.Post", new[] { "Comment_Id" });
            DropIndex("dbo.Post", new[] { "Category_Id" });
            DropTable("dbo.TagPost");
            DropTable("dbo.Comment");
            DropTable("dbo.Tag");
            DropTable("dbo.Post");
            DropTable("dbo.Category");
        }
    }
}
