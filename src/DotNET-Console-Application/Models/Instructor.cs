using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNET_Console_Application.Models
{
    [Table("instructor")]
    public partial class Instructor : Person
    {
        [InverseProperty(nameof(Models.Course.Instructor))]
        public virtual IEnumerable<Course> Courses { get; set; }

    }
}


