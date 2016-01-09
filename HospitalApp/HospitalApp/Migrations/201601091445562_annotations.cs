namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class annotations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Doctor", "FirstName", c => c.String(nullable: false));
            AlterColumn("dbo.Doctor", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Patient", "DoB", c => c.DateTime());
            CreateIndex("dbo.Patient", "TB", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Patient", new[] { "TB" });
            AlterColumn("dbo.Patient", "DoB", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Doctor", "LastName", c => c.String());
            AlterColumn("dbo.Doctor", "FirstName", c => c.String());
        }
    }
}
