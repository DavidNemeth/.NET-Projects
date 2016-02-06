namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class javar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Diagnosztika", "JavitasAr", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Diagnosztika", "JavitasAr");
        }
    }
}
