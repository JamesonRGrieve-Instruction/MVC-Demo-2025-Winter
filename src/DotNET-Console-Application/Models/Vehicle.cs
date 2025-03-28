using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    [Table("vehicle")]
    public partial class Vehicle
    {
        [Key]
        [Column("vin", TypeName = "TEXT")]
        public string VIN { get; set; }

        [Column("model_year", TypeName = "INTEGER")]
        public int ModelYear { get; set; }
        [Column("colour", TypeName = "TEXT")]
        public string Colour { get; set; }


        [Column("model_id", TypeName = "INTEGER")]
        public int? ModelID { get; set; }

        [ForeignKey(nameof(ModelID))]
        [InverseProperty(nameof(Models.Model.Vehicles))]
        public virtual Model Model { get; set; }
    }
    public partial class CodeFirstContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        partial void OnModelCreatingPartialVehicle(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasData([
                    new Vehicle() { VIN="4A3AL54F3XE067712", ModelID=-1, Colour="Red", ModelYear=1999 },
                    new Vehicle() { VIN = "JA3AN74K8XY001384", ModelID = -2, Colour = "Red", ModelYear = 1999 },
                    new Vehicle() { VIN = " JH4NA1153MT000743", ModelID = -3, Colour = "Silver", ModelYear = 1991 },
                    new Vehicle() { VIN = "JHMAP21475S008443", ModelID = -4, Colour = "Steel Blue", ModelYear = 2005 },
                    new Vehicle() { VIN = "JT2JA82J8S0028274", ModelID = -5, Colour = "Black", ModelYear = 1995 },
                    new Vehicle() { VIN = " JTDFR320320052403", ModelID = -6, Colour = "Green", ModelYear = 2002 },
                    new Vehicle() { VIN = " JN1RZ24A1LX002317", ModelID = -7, Colour = "Red", ModelYear = 1990 },
                    new Vehicle() { VIN = "BCNR33004655", ModelID = -8, Colour = "Purple", ModelYear = 1995 },
                    ]);
                entity.HasOne(child => child.Model)
                      .WithMany(parent => parent.Vehicles)
                      .OnDelete(DeleteBehavior.SetNull)
                      .HasConstraintName($"FK_{nameof(Vehicle)}_{nameof(Model)}");

                entity.HasIndex(e => e.ModelID).HasDatabaseName($"FK_{nameof(Vehicle)}_{nameof(Model)}");
            });
        }
    }
}


