namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _ : DbMigration
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Disease",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Conclusion = c.String(),
                        DoctorID = c.Int(nullable: false),
                        MedHistory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MedHistory", t => t.MedHistory_Id, cascadeDelete: true)
                .Index(t => t.MedHistory_Id);
            
            CreateTable(
                "dbo.MedHistory",
                c => new
                    {
                        Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Patient", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Patient",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hospital",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MedHistory", "Id", "dbo.Patient");
            DropForeignKey("dbo.Disease", "MedHistory_Id", "dbo.MedHistory");
            DropIndex("dbo.MedHistory", new[] { "Id" });
            DropIndex("dbo.Disease", new[] { "MedHistory_Id" });
            DropTable("dbo.Hospital");
            DropTable("dbo.Doctor");
            DropTable("dbo.Patient");
            DropTable("dbo.MedHistory");
            DropTable("dbo.Disease");
            DropTable("dbo.Appointment");
        }
    }
}
