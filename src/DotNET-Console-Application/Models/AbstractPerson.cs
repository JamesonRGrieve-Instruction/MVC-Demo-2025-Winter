using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNET_Console_Application.Models
{
    public abstract class Person : Entity
    {
        [Required]
        [Column("first_name", TypeName = "TEXT")]
        public string FirstName { get; set; }
        [Required]
        [Column("last_name", TypeName = "TEXT")]
        public string LastName { get; set; }
    }
}


