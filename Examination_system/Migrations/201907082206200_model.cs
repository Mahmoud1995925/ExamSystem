namespace Examination_system.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        Answer_id = c.Int(nullable: false, identity: true),
                        Answer_desc = c.String(),
                    })
                .PrimaryKey(t => t.Answer_id);
            
            CreateTable(
                "dbo.Question_Asnwer",
                c => new
                    {
                        Question_id = c.Int(nullable: false),
                        Answer_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Question_id, t.Answer_id })
                .ForeignKey("dbo.Answers", t => t.Answer_id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_id, cascadeDelete: true)
                .Index(t => t.Question_id)
                .Index(t => t.Answer_id);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        Question_id = c.Int(nullable: false, identity: true),
                        Question_desc = c.String(),
                        Correct_Answer_id = c.Int(nullable: false),
                        Question_Grade = c.Int(),
                    })
                .PrimaryKey(t => t.Question_id);
            
            CreateTable(
                "dbo.Exam_Question",
                c => new
                    {
                        Exam_id = c.Int(nullable: false),
                        Question_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exam_id, t.Question_id })
                .ForeignKey("dbo.Exams", t => t.Exam_id, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_id, cascadeDelete: true)
                .Index(t => t.Exam_id)
                .Index(t => t.Question_id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Exam_id = c.Int(nullable: false, identity: true),
                        Exam_Name = c.String(maxLength: 20),
                        Exam_Desc = c.String(maxLength: 30),
                        Exam_Grade = c.Int(),
                    })
                .PrimaryKey(t => t.Exam_id);
            
            CreateTable(
                "dbo.ExamCourses",
                c => new
                    {
                        Exam_id = c.Int(nullable: false),
                        Course_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Exam_id, t.Course_id })
                .ForeignKey("dbo.Courses", t => t.Course_id, cascadeDelete: true)
                .ForeignKey("dbo.Exams", t => t.Exam_id, cascadeDelete: true)
                .Index(t => t.Exam_id)
                .Index(t => t.Course_id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Course_id = c.Int(nullable: false, identity: true),
                        Course_Name = c.String(maxLength: 20),
                        Course_Desc = c.String(maxLength: 30),
                        Info = c.String(),
                    })
                .PrimaryKey(t => t.Course_id);
            
            CreateTable(
                "dbo.Student_course",
                c => new
                    {
                        Course_id = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Course_id, t.UserId })
                .ForeignKey("dbo.Courses", t => t.Course_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Course_id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        std_address = c.String(maxLength: 20),
                        std_DOB = c.DateTime(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Problems",
                c => new
                    {
                        Problem_id = c.Int(nullable: false, identity: true),
                        Problem_Desc = c.String(),
                        User_id = c.Int(nullable: false),
                        Student_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Problem_id)
                .ForeignKey("dbo.AspNetUsers", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Student_exam",
                c => new
                    {
                        Exam_id = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => new { t.Exam_id, t.UserId })
                .ForeignKey("dbo.Exams", t => t.Exam_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.Exam_id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Question_Asnwer", "Question_id", "dbo.Questions");
            DropForeignKey("dbo.Exam_Question", "Question_id", "dbo.Questions");
            DropForeignKey("dbo.ExamCourses", "Exam_id", "dbo.Exams");
            DropForeignKey("dbo.Student_exam", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Student_exam", "Exam_id", "dbo.Exams");
            DropForeignKey("dbo.Student_course", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Problems", "Student_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Student_course", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.ExamCourses", "Course_id", "dbo.Courses");
            DropForeignKey("dbo.Exam_Question", "Exam_id", "dbo.Exams");
            DropForeignKey("dbo.Question_Asnwer", "Answer_id", "dbo.Answers");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Student_exam", new[] { "UserId" });
            DropIndex("dbo.Student_exam", new[] { "Exam_id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Problems", new[] { "Student_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Student_course", new[] { "UserId" });
            DropIndex("dbo.Student_course", new[] { "Course_id" });
            DropIndex("dbo.ExamCourses", new[] { "Course_id" });
            DropIndex("dbo.ExamCourses", new[] { "Exam_id" });
            DropIndex("dbo.Exam_Question", new[] { "Question_id" });
            DropIndex("dbo.Exam_Question", new[] { "Exam_id" });
            DropIndex("dbo.Question_Asnwer", new[] { "Answer_id" });
            DropIndex("dbo.Question_Asnwer", new[] { "Question_id" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Student_exam");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Problems");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Student_course");
            DropTable("dbo.Courses");
            DropTable("dbo.ExamCourses");
            DropTable("dbo.Exams");
            DropTable("dbo.Exam_Question");
            DropTable("dbo.Questions");
            DropTable("dbo.Question_Asnwer");
            DropTable("dbo.Answers");
        }
    }
}
