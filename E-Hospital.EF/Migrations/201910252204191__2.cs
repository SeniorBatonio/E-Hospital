namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DateTimeInAppointment", "Id", "dbo.Appointment");
            DropIndex("dbo.DateTimeInAppointment", new[] { "Id" });
            CreateTable(
                "dbo.DoctorAppointmentDateTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDateTime = c.DateTime(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id);
            
            AddColumn("dbo.Appointment", "DoctorAppointmentDateTimeId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointment", "DoctorId");
            DropTable("dbo.DateTimeInAppointment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DateTimeInAppointment",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AppointmentDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointment", "DoctorId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DoctorAppointmentDateTime", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.DoctorAppointmentDateTime", new[] { "Doctor_Id" });
            DropColumn("dbo.Appointment", "DoctorAppointmentDateTimeId");
            DropTable("dbo.DoctorAppointmentDateTime");
            CreateIndex("dbo.DateTimeInAppointment", "Id");
            AddForeignKey("dbo.DateTimeInAppointment", "Id", "dbo.Appointment", "Id");
        }
    }
}
