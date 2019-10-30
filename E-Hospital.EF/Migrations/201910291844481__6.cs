namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disease", "MedHistory_Id", "dbo.MedHistory");
            DropForeignKey("dbo.MedHistory", "Id", "dbo.Patient");
            DropIndex("dbo.Disease", new[] { "MedHistory_Id" });
            DropIndex("dbo.MedHistory", new[] { "Id" });
            DropTable("dbo.Disease");
            DropTable("dbo.MedHistory");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MedHistory",
                c => new
                    {
                        Id = c.Int(nullable: false),
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MedHistory", "Id");
            CreateIndex("dbo.Disease", "MedHistory_Id");
            AddForeignKey("dbo.MedHistory", "Id", "dbo.Patient", "Id");
            AddForeignKey("dbo.Disease", "MedHistory_Id", "dbo.MedHistory", "Id", cascadeDelete: true);
        }
    }
}
