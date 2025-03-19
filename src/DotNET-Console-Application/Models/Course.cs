using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNET_Console_Application.Models
{
    [Table("course")]
    public partial class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "INTEGER")]
        public int ID { get; set; }

        [Required]
        [Column("code", TypeName = "TEXT")]
        public string Code { get; set; }
        [Required]
        [Column("name", TypeName = "TEXT")]
        public string Name { get; set; }
    }
}


