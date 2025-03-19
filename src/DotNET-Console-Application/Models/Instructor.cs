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

    }
}


