using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    [Table("student")]
    public partial class Student : Person
    {
        [Column("course_id", TypeName = "INTEGER")]
        public int? CourseID { get; set; }

        [ForeignKey(nameof(CourseID))]
        [InverseProperty(nameof(Models.Course.Students))]
        public virtual Course Course { get; set; }
    }
    public partial class CodeFirstContext
    {
        public DbSet<Student> Students { get; set; }
        partial void OnModelCreatingPartialStudent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasData([new Student() {
                    ID = -1,
                    FirstName = "Jane",
                    LastName = "Doe",
                    CourseID = -1
                }]);
                entity.HasOne(child => child.Course)
                      .WithMany(parent => parent.Students)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName($"FK_{nameof(Student)}_{nameof(Course)}");

                entity.HasIndex(e => e.CourseID).HasDatabaseName($"FK_{nameof(Student)}_{nameof(Course)}");
            });
        }
    }
}


