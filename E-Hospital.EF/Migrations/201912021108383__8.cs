namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Doctor", "Shifts_StartTime_Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "Shifts_StartTime_Minute", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "Shifts_EndTime_Hour", c => c.Int(nullable: false));
            AddColumn("dbo.Doctor", "Shifts_EndTime_Minute", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Doctor", "Shifts_EndTime_Minute");
            DropColumn("dbo.Doctor", "Shifts_EndTime_Hour");
            DropColumn("dbo.Doctor", "Shifts_StartTime_Minute");
            DropColumn("dbo.Doctor", "Shifts_StartTime_Hour");
        }
    }
}
