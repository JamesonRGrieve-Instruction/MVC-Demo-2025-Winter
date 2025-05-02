using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ProjectName.Models
{
    [Table("vehicle")]
    public partial class Vehicle
    {
        [Key]
        [Column("vin", TypeName = "CHAR(17)")]
        [RegularExpression("^[A-HJ-NPR-Z0-9]{17}$", ErrorMessage = "VIN must be 17 characters long and contain only uppercase letters and numbers, excluding I, O, Q.")]
        [StringLength(17)]
        public string VIN { get; set; }

        [Column("model_year", TypeName = "INTEGER")]
        [Required]
        [Range(1900, 2050, ErrorMessage = "Model year must be between 1900 and 2050.")]
        public int ModelYear { get; set; }
        [Column("colour", TypeName = "TEXT")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Colour must be between 3 and 50 characters.")]
        public string Colour { get; set; }

        [Column("user_email", TypeName = "VARCHAR(50)")]
        public string UserEmail { get; set; }
        [Column("model", TypeName = "VARCHAR(50)")]
        [Required]
        [StringLength(50, ErrorMessage = "Model length cannot exceed 50 characters.")]
        public string Model { get; set; }
        [Column("manufacturer", TypeName = "VARCHAR(50)")]
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Manufacturer must be between 3 and 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s-]+$", ErrorMessage = "Manufacturer can only contain letters, spaces, and hyphens.")]
        public string Manufacturer { get; set; }
        [Column("purchase_date", TypeName = "DATETIME")]
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Column("sale_date", TypeName = "DATETIME")]
        public DateTime? SaleDate { get; set; }

        // [Column("model_id", TypeName = "INTEGER")]
        // public int? ModelID { get; set; }

        // [ForeignKey(nameof(ModelID))]
        // [InverseProperty(nameof(Models.Model.Vehicles))]
        // public virtual Model Model { get; set; }

    }
}


