namespace Examination_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColum : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Full_name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Full_name");
        }
    }
}
