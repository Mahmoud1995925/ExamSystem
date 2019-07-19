namespace Examination_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Problems", "User_id", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Problems", "User_id", c => c.Int(nullable: false));
        }
    }
}
