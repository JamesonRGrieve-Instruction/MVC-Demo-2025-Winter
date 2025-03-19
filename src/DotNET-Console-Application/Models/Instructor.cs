using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNET_Console_Application.Models
{
    [Table("instructor")]
    public partial class Instructor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id", TypeName = "INTEGER")]
        public int ID { get; set; }

        [Required]
        [Column("first_name", TypeName = "TEXT")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "TEXT")]
        public string LastName { get; set; }

    }
}


