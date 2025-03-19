using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}


