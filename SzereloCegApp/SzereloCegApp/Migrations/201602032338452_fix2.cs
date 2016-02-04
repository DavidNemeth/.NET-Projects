namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fix2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Diagnosztika", "MunkaIdo");
            DropColumn("dbo.Diagnosztika", "Anyagköltseg");
            DropColumn("dbo.Szerelo", "Oraber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Szerelo", "Oraber", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AddColumn("dbo.Diagnosztika", "Anyagköltseg", c => c.Decimal(nullable: false, precision: 18, scale: 0));
            AddColumn("dbo.Diagnosztika", "MunkaIdo", c => c.Int(nullable: false));
        }
    }
}
