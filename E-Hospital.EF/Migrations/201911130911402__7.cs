namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _7 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DoctorAppointmentTime", "Schedule_Id", "dbo.Schedule");
            DropForeignKey("dbo.Schedule", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.Schedule", new[] { "Doctor_Id" });
            DropIndex("dbo.DoctorAppointmentTime", new[] { "Schedule_Id" });
            CreateTable(
                "dbo.AppointmentTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Time_Hour = c.Int(nullable: false),
                        Time_Minute = c.Int(nullable: false),
                        Schedule_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schedule", t => t.Schedule_Id, cascadeDelete: true)
                .Index(t => t.Schedule_Id);
            
            AddColumn("dbo.Schedule", "DoctorId", c => c.Int(nullable: false));
            DropColumn("dbo.Schedule", "Doctor_Id");
            DropTable("dbo.DoctorAppointmentTime");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DoctorAppointmentTime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AppointmentTime = c.DateTime(nullable: false),
                        Schedule_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Schedule", "Doctor_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.AppointmentTime", "Schedule_Id", "dbo.Schedule");
            DropIndex("dbo.AppointmentTime", new[] { "Schedule_Id" });
            DropColumn("dbo.Schedule", "DoctorId");
            DropTable("dbo.AppointmentTime");
            CreateIndex("dbo.DoctorAppointmentTime", "Schedule_Id");
            CreateIndex("dbo.Schedule", "Doctor_Id");
            AddForeignKey("dbo.Schedule", "Doctor_Id", "dbo.Doctor", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DoctorAppointmentTime", "Schedule_Id", "dbo.Schedule", "Id", cascadeDelete: true);
        }
    }
}
