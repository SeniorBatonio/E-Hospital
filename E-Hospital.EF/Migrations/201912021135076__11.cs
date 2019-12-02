namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Shifts", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.Shifts", new[] { "Doctor_Id" });
            AlterColumn("dbo.Shifts", "Doctor_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Shifts", "Doctor_Id");
            AddForeignKey("dbo.Shifts", "Doctor_Id", "dbo.Doctor", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Shifts", "Doctor_Id", "dbo.Doctor");
            DropIndex("dbo.Shifts", new[] { "Doctor_Id" });
            AlterColumn("dbo.Shifts", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Shifts", "Doctor_Id");
            AddForeignKey("dbo.Shifts", "Doctor_Id", "dbo.Doctor", "Id");
        }
    }
}
