using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
}


