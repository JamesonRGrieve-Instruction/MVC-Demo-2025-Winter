using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    [Table("course")]
    public partial class Course : Entity
    {

        [Required]
        [Column("code", TypeName = "TEXT")]
        public string Code { get; set; }
        [Required]
        [Column("name", TypeName = "TEXT")]
        public string Name { get; set; }

        [Column("instructor_id", TypeName = "INTEGER")]
        public int? InstructorID { get; set; }

        [ForeignKey(nameof(InstructorID))]
        [InverseProperty(nameof(Models.Instructor.Courses))]
        public virtual Instructor Instructor { get; set; }

        [InverseProperty(nameof(Models.Student.Course))]
        public virtual IEnumerable<Student> Students { get; set; }
    }
    public partial class CodeFirstContext
    {
        public DbSet<Course> Courses { get; set; }
        partial void OnModelCreatingPartialCourse(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.HasOne(child => child.Instructor)
                      .WithMany(parent => parent.Courses)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName($"FK_{nameof(Course)}_{nameof(Instructor)}");

                entity.HasIndex(e => e.InstructorID).HasDatabaseName($"FK_{nameof(Course)}_{nameof(Instructor)}");

                // Seed data for Course
                entity.HasData(
                    new Course() { ID = -1, Name = "Introduction to Programming", Code = "COMP101", InstructorID = -1 },
                    new Course() { ID = -2, Name = "Introduction to Databases", Code = "DATA101", InstructorID = -1 }
                );
            });
        }
    }
}


