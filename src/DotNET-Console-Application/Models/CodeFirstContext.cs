using Microsoft.EntityFrameworkCore;

namespace DotNET_Console_Application.Models
{
    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext() { }
        public CodeFirstContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=CodeFirst.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Call other partial OnModelCreating methods
            OnModelCreatingPartialCourse(modelBuilder);
            OnModelCreatingPartialInstructor(modelBuilder);
            OnModelCreatingPartialStudent(modelBuilder);
        }

        partial void OnModelCreatingPartialCourse(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartialInstructor(ModelBuilder modelBuilder);
        partial void OnModelCreatingPartialStudent(ModelBuilder modelBuilder);
    }

}