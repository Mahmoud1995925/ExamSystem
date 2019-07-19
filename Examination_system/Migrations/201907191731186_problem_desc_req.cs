namespace Examination_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class problem_desc_req : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Problems", "Problem_Desc", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Problems", "Problem_Desc", c => c.String());
        }
    }
}
