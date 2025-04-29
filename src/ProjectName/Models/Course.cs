using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectName.Models;
[Table("courses")]
public class Course
{
    [Key]
    [Column("course_code")]
    public string CourseCode { get; set; }
    [Column("user_id")]
    public string UserID { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }

}