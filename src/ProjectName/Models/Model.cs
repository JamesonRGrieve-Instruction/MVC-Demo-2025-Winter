using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    [Table("model")]
    public partial class Model : Entity
    {

        [Required]
        [Column("name", TypeName = "TEXT")]
        public string Name { get; set; }

        [Column("manufacturer_id", TypeName = "INTEGER")]
        public int? ManufacturerID { get; set; }

        [ForeignKey(nameof(ManufacturerID))]
        [InverseProperty(nameof(Models.Manufacturer.Models))]
        public virtual Manufacturer Manufacturer { get; set; }

        [InverseProperty(nameof(Vehicle.Model))]
        public virtual IEnumerable<Vehicle> Vehicles { get; set; }
    }
    public partial class CodeFirstContext
    {
        public DbSet<Model> Models { get; set; }
        partial void OnModelCreatingPartialModel(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasOne(child => child.Manufacturer)
                      .WithMany(parent => parent.Models)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName($"FK_{nameof(Model)}_{nameof(Manufacturer)}");

                entity.HasIndex(e => e.ManufacturerID).HasDatabaseName($"FK_{nameof(Model)}_{nameof(Manufacturer)}");

                // Seed data for Model
                entity.HasData(
                    new Model() { ID = -1, ManufacturerID = -1, Name = "Eclipse" },
                    new Model() { ID = -2, ManufacturerID = -1, Name = "3000GT" },
                    new Model() { ID = -3, ManufacturerID = -2, Name = "NSX" },
                    new Model() { ID = -4, ManufacturerID = -2, Name = "S2000" },
                    new Model() { ID = -5, ManufacturerID = -3, Name = "Supra" },
                    new Model() { ID = -6, ManufacturerID = -3, Name = "MR2" },
                    new Model() { ID = -7, ManufacturerID = -4, Name = "300ZX" },
                    new Model() { ID = -8, ManufacturerID = -4, Name = "GTR" }
                );
            });
        }
    }
}


