using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using DotNetEnv;
namespace ProjectName.Models
{
    public partial class CarsContext : IdentityDbContext
    {
        public CarsContext() { }
        public CarsContext(DbContextOptions options) : base(options) { }


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
                if (Environment.GetEnvironmentVariable("DB_TYPE") == "sqlite")
                {
                    optionsBuilder.UseSqlite($"Data Source={Environment.GetEnvironmentVariable("DB_NAME")}.db");
                }
                else if (Environment.GetEnvironmentVariable("DB_TYPE") == "mariadb")
                {
                    optionsBuilder.UseMySql($"server=localhost;database={Environment.GetEnvironmentVariable("DB_NAME")};user={Environment.GetEnvironmentVariable("DB_USER")};password={Environment.GetEnvironmentVariable("DB_PASSWORD")}", new MySqlServerVersion(new Version(11, 8, 1)));
                }
                else if (Environment.GetEnvironmentVariable("DB_TYPE") == "postgres")
                {
                    optionsBuilder.UseNpgsql($"Host=localhost;Port={Environment.GetEnvironmentVariable("DB_PORT")};Username={Environment.GetEnvironmentVariable("DB_USER")};Password={Environment.GetEnvironmentVariable("DB_PASSWORD")};Database={Environment.GetEnvironmentVariable("DB_NAME")};");
                }
                else
                {
                    throw new Exception("Unsupported DB_TYPE.");
                }
            }
        }
        public DbSet<Vehicle> Vehicles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }

}