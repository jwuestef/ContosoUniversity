using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {


        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }


        //This code creates a DbSet property for each entity set.
        //In Entity Framework terminology, an entity set typically corresponds to a database table, and an entity corresponds to a row in the table.
        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }
        //You could've omitted the DbSet<Enrollment> and DbSet<Course> statements and it would work the same.
        //The Entity Framework would include them implicitly because the Student entity references the Enrollment entity and the Enrollment entity references the Course entity.
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
        public DbSet<CourseAssignment> CourseAssignments { get; set; }


        //When the database is created, EF creates tables that have names the same as the DbSet property names.
        //Property names for collections are typically plural (Students rather than Student), but developers disagree about whether table names should be pluralized or not.
        //For these tutorials you'll override the default behavior by specifying singular table names in the DbContext.
        //To do that, add:
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            modelBuilder.Entity<Student>().ToTable("Student");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Instructor>().ToTable("Instructor");
            modelBuilder.Entity<OfficeAssignment>().ToTable("OfficeAssignment");
            modelBuilder.Entity<CourseAssignment>().ToTable("CourseAssignment");

            modelBuilder.Entity<CourseAssignment>()
                .HasKey(ca => new { ca.CourseID, ca.InstructorID });
        }


    }
}
