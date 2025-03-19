using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    [Table("instructor")]
    public partial class Instructor : Person
    {
        [InverseProperty(nameof(Models.Course.Instructor))]
        public virtual IEnumerable<Course> Courses { get; set; }

    }
    public partial class CodeFirstContext
    {
        public DbSet<Instructor> Instructors { get; set; }
        partial void OnModelCreatingPartialInstructor(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Instructor>(entity =>
            {
                entity.HasData(new Instructor() { ID = -1, FirstName = "John", LastName = "Doe" });
            });
        }
    }
}


