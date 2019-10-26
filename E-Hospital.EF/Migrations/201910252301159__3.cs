namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        DoctorAppointmentDateTimeId = c.Int(nullable: false),
                        AppointmentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Appointment", "ReservationId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointment", "DoctorAppointmentDateTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "DoctorAppointmentDateTimeId", c => c.Int(nullable: false));
            DropColumn("dbo.Appointment", "ReservationId");
            DropTable("dbo.Reservation");
        }
    }
}
