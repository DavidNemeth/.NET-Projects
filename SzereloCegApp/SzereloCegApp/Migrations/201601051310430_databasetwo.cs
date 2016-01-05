namespace SzereloCegApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class databasetwo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnosztika",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HibaNeve = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.GepJarmu",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Marka = c.String(nullable: false),
                        Tipus = c.String(nullable: false),
                        Rendszam = c.String(nullable: false),
                        GyartasiEv = c.DateTime(nullable: false),
                        UgyfelID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ugyfel", t => t.UgyfelID)
                .Index(t => t.UgyfelID);
            
            CreateTable(
                "dbo.GepJarmuDiagnosztika",
                c => new
                    {
                        GepJarmu_ID = c.Int(nullable: false),
                        Diagnosztika_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.GepJarmu_ID, t.Diagnosztika_ID })
                .ForeignKey("dbo.GepJarmu", t => t.GepJarmu_ID, cascadeDelete: true)
                .ForeignKey("dbo.Diagnosztika", t => t.Diagnosztika_ID, cascadeDelete: true)
                .Index(t => t.GepJarmu_ID)
                .Index(t => t.Diagnosztika_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GepJarmu", "UgyfelID", "dbo.Ugyfel");
            DropForeignKey("dbo.GepJarmuDiagnosztika", "Diagnosztika_ID", "dbo.Diagnosztika");
            DropForeignKey("dbo.GepJarmuDiagnosztika", "GepJarmu_ID", "dbo.GepJarmu");
            DropIndex("dbo.GepJarmuDiagnosztika", new[] { "Diagnosztika_ID" });
            DropIndex("dbo.GepJarmuDiagnosztika", new[] { "GepJarmu_ID" });
            DropIndex("dbo.GepJarmu", new[] { "UgyfelID" });
            DropTable("dbo.GepJarmuDiagnosztika");
            DropTable("dbo.GepJarmu");
            DropTable("dbo.Diagnosztika");
        }
    }
}
