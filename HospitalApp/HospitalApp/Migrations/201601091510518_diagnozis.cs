namespace HospitalApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class diagnozis : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condition",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ConditionName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PatientCondition",
                c => new
                    {
                        Patient_ID = c.Int(nullable: false),
                        Condition_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Patient_ID, t.Condition_ID })
                .ForeignKey("dbo.Patient", t => t.Patient_ID, cascadeDelete: true)
                .ForeignKey("dbo.Condition", t => t.Condition_ID, cascadeDelete: true)
                .Index(t => t.Patient_ID)
                .Index(t => t.Condition_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PatientCondition", "Condition_ID", "dbo.Condition");
            DropForeignKey("dbo.PatientCondition", "Patient_ID", "dbo.Patient");
            DropIndex("dbo.PatientCondition", new[] { "Condition_ID" });
            DropIndex("dbo.PatientCondition", new[] { "Patient_ID" });
            DropTable("dbo.PatientCondition");
            DropTable("dbo.Condition");
        }
    }
}
