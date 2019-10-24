namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDate = c.DateTime(nullable: false),
                        PatientId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.Patient", t => t.PatientId, cascadeDelete: true)
                .Index(t => t.PatientId)
                .Index(t => t.DoctorId);
            
            CreateTable(
                "dbo.Doctor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Profession = c.String(),
                        HospitalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hospital", t => t.HospitalID, cascadeDelete: true)
                .Index(t => t.HospitalID);
            
            CreateTable(
                "dbo.Hospital",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                        MedHistoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MedHistory",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patient", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Disease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conclusion = c.String(),
                        MedHistoryId = c.Int(nullable: false),
                        DoctorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.DoctorId, cascadeDelete: true)
                .ForeignKey("dbo.MedHistory", t => t.MedHistoryId, cascadeDelete: true)
                .Index(t => t.MedHistoryId)
                .Index(t => t.DoctorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointment", "PatientId", "dbo.Patient");
            DropForeignKey("dbo.MedHistory", "Id", "dbo.Patient");
            DropForeignKey("dbo.Disease", "MedHistoryId", "dbo.MedHistory");
            DropForeignKey("dbo.Disease", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Appointment", "DoctorId", "dbo.Doctor");
            DropForeignKey("dbo.Doctor", "HospitalID", "dbo.Hospital");
            DropIndex("dbo.Disease", new[] { "DoctorId" });
            DropIndex("dbo.Disease", new[] { "MedHistoryId" });
            DropIndex("dbo.MedHistory", new[] { "Id" });
            DropIndex("dbo.Doctor", new[] { "HospitalID" });
            DropIndex("dbo.Appointment", new[] { "DoctorId" });
            DropIndex("dbo.Appointment", new[] { "PatientId" });
            DropTable("dbo.Disease");
            DropTable("dbo.MedHistory");
            DropTable("dbo.Patient");
            DropTable("dbo.Hospital");
            DropTable("dbo.Doctor");
            DropTable("dbo.Appointment");
        }
    }
}
