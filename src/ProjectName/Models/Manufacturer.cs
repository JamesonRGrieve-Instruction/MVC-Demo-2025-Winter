using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ProjectName.Models
{
    [Table("manufacturer")]
    public partial class Manufacturer : Entity
    {
        [Required]
        [Column("name", TypeName = "TEXT")]
        public string Name { get; set; }

        [InverseProperty(nameof(Model.Manufacturer))]
        public virtual IEnumerable<Model> Models { get; set; }

    }
    public partial class CodeFirstContext
    {
        public DbSet<Manufacturer> Manufacturers { get; set; }
        partial void OnModelCreatingPartialManufacturer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasData(
                    new Manufacturer() { ID = -1, Name = "Mitsubishi" },
                    new Manufacturer() { ID = -2, Name = "Honda" },
                    new Manufacturer() { ID = -3, Name = "Toyota" },
                    new Manufacturer() { ID = -4, Name = "Nissan" }
                );
            });
        }
    }
}


