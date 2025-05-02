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
        [StringLength(17)]
        public string VIN { get; set; }

        [Column("model_year", TypeName = "INTEGER")]
        public int ModelYear { get; set; }
        [Column("colour", TypeName = "TEXT")]
        public string Colour { get; set; }

        [Column("user_email", TypeName = "VARCHAR(50)")]
        public string UserEmail { get; set; }
        [Column("model", TypeName = "VARCHAR(50)")]
        public string Model { get; set; }
        [Column("manufacturer", TypeName = "VARCHAR(50)")]
        public string Manufacturer { get; set; }
        [Column("purchase_date", TypeName = "DATETIME")]
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


