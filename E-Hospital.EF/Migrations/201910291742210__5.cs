﻿namespace E_Hospital.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patient", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patient", "Email");
        }
    }
}
