namespace Examination_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columcourse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Courses", "Course_Desc", c => c.String(maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Course_Desc", c => c.String(maxLength: 30));
        }
    }
}
