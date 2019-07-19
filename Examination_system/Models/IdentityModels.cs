using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Examination_system.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Display(Name = "Student Address")]
        [MaxLength(20)]
        public string std_address { set; get; }

        [Display(Name = "Student Date Of Birth")]
        [Required]
        public DateTime? std_DOB { set; get; }
        [Display(Name = "Full Name")]
        [Required]
        public String Full_name { set; get; }
        public virtual ICollection<Student_exam> Student_Exams { get; set; }
        public virtual ICollection<Student_course> Student_Course { get; set; }

        public virtual ICollection<Problem> Complains { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Student_exam> student_Exams { get; set; }
        public DbSet<Problem> problems { get; set; }
        public DbSet<Course> courses { get; set; }
        public DbSet<Answer> answers { get; set; }
        public DbSet<Exam_Question> Exam_Questions { get; set; }
        public DbSet<ExamCourse> ExamCourses { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Question_Asnwer> Question_Asnwers { get; set; }
        public DbSet<Student_course> student_Courses { get; set; }


        /* protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<Student>()
                 .HasMany(t => t.exams)
                 .WithMany(t => t.Students)
                 .Map(m =>
                 {
                     m.ToTable("StudentExams");
                     m.MapLeftKey("Std_id");
                     m.MapRightKey("Exam_id");
                 });
            base.OnModelCreating(modelBuilder);
         }*/

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}