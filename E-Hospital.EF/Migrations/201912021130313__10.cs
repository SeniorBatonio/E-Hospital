namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StartTime_Hour = c.Int(nullable: false),
                        StartTime_Minute = c.Int(nullable: false),
                        EndTime_Hour = c.Int(nullable: false),
                        EndTime_Minute = c.Int(nullable: false),
                        Doctor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctor", t => t.Doctor_Id)
                .Index(t => t.Doctor_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.Shifts", new[] { "Doctor_Id" });
            DropTable("dbo.Shifts");
        }
    }
}
