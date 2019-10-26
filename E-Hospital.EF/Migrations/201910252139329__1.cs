namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DateTimeInAppointment",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        AppointmentDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Appointment", t => t.Id)
                .Index(t => t.Id);
            
            DropColumn("dbo.Appointment", "AppointmentDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointment", "AppointmentDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.DateTimeInAppointment", "Id", "dbo.Appointment");
            DropIndex("dbo.DateTimeInAppointment", new[] { "Id" });
            DropTable("dbo.DateTimeInAppointment");
        }
    }
}
