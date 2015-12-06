namespace BlogEngine.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogContext1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Category", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Category", "UrlOpt", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Tittle", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "Meta", c => c.String(nullable: false));
            AlterColumn("dbo.Post", "UrlOpt", c => c.String(nullable: false));
            AlterColumn("dbo.Tag", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Tag", "UrlOpt", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "UrlOpt", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Comment", "UserName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comment", "UserName", c => c.String());
            AlterColumn("dbo.Comment", "Body", c => c.String());
            AlterColumn("dbo.Comment", "UrlOpt", c => c.String());
            AlterColumn("dbo.Tag", "UrlOpt", c => c.String());
            AlterColumn("dbo.Tag", "Name", c => c.String());
            AlterColumn("dbo.Post", "UrlOpt", c => c.String());
            AlterColumn("dbo.Post", "Meta", c => c.String());
            AlterColumn("dbo.Post", "Body", c => c.String());
            AlterColumn("dbo.Post", "Description", c => c.String());
            AlterColumn("dbo.Post", "Tittle", c => c.String());
            AlterColumn("dbo.Category", "UrlOpt", c => c.String());
            AlterColumn("dbo.Category", "Name", c => c.String());
        }
    }
}
