namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DoctorAppointmentDateTime", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.DoctorAppointmentDateTime", new[] { "Doctor_Id" });
            CreateTable(
                "dbo.Schedule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.DoctorAppointmentTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentTime = c.DateTime(nullable: false),
                        Schedule_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedule", t => t.Schedule_Id, cascadeDelete: true)
                .Index(t => t.Schedule_Id);
            
            DropTable("dbo.DoctorAppointmentDateTime");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoctorAppointmentDateTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentDateTime = c.DateTime(nullable: false),
                        Doctor_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Schedule", "Doctor_Id", "dbo.Doctor");
            DropForeignKey("dbo.DoctorAppointmentTime", "Schedule_Id", "dbo.Schedule");
            DropIndex("dbo.DoctorAppointmentTime", new[] { "Schedule_Id" });
            DropIndex("dbo.Schedule", new[] { "Doctor_Id" });
            DropTable("dbo.DoctorAppointmentTime");
            DropTable("dbo.Schedule");
            CreateIndex("dbo.DoctorAppointmentDateTime", "Doctor_Id");
            AddForeignKey("dbo.DoctorAppointmentDateTime", "Doctor_Id", "dbo.Doctor", "Id", cascadeDelete: true);
        }
    }
}
