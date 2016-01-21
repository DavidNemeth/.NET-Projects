namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Diagnosztika", "Anyagköltseg", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AlterColumn("dbo.Szerelo", "Oraber", c => c.Decimal(nullable: false, precision: 18, scale: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Szerelo", "Oraber", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Diagnosztika", "Anyagköltseg", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
