namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        Middlename = c.String(),
                        Lastname = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TB = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DoB = c.DateTime(),
                        YrVisits = c.Byte(nullable: false),
                        DoctorID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Doctor", t => t.DoctorID)
                .Index(t => t.DoctorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patient", "DoctorID", "dbo.Doctor");
            DropIndex("dbo.Patient", new[] { "DoctorID" });
            DropTable("dbo.Patient");
            DropTable("dbo.Doctor");
        }
    }
}
