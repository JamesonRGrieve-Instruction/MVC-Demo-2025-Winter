using Microsoft.EntityFrameworkCore;
using DotNetEnv;
namespace DotNET_Console_Application.Models
{
    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext() { }
        public CodeFirstContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            string envPath = ".env";
            int tries = 10;
            while (!File.Exists(envPath) && tries > 0)
            {
                tries--;
                envPath = $"../{envPath}";
            }
            Env.Load(envPath);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite($"Data Source={Environment.GetEnvironmentVariable("DB_NAME")}.db");
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