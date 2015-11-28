namespace BlogEngine.Migrations.BlogContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Blog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CategoryToPost",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.CategoryId })
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tittle = c.String(),
                        Description = c.String(),
                        Meta = c.String(),
                        UrlOpt = c.String(),
                        PostedDate = c.DateTime(nullable: false),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PostId = c.Int(nullable: false),
                        Body = c.String(),
                        UserName = c.String(),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
            CreateTable(
                "dbo.TagToPost",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        TagId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.TagId })
                .ForeignKey("dbo.Post", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Tag", t => t.TagId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.TagId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagToPost", "TagId", "dbo.Tag");
            DropForeignKey("dbo.TagToPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.CategoryToPost", "PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "PostId", "dbo.Post");
            DropForeignKey("dbo.CategoryToPost", "CategoryId", "dbo.Category");
            DropIndex("dbo.TagToPost", new[] { "TagId" });
            DropIndex("dbo.TagToPost", new[] { "PostId" });
            DropIndex("dbo.Comment", new[] { "PostId" });
            DropIndex("dbo.CategoryToPost", new[] { "CategoryId" });
            DropIndex("dbo.CategoryToPost", new[] { "PostId" });
            DropTable("dbo.Tag");
            DropTable("dbo.TagToPost");
            DropTable("dbo.Comment");
            DropTable("dbo.Post");
            DropTable("dbo.CategoryToPost");
            DropTable("dbo.Category");
        }
    }
}
