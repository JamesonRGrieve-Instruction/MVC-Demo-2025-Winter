using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetEnv;
namespace ProjectName.Models
{
    public partial class CourseContext : DbContext
    {

        public CourseContext()
        {
        }

        public CourseContext(DbContextOptions<CourseContext> options) : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }

        public static void LoadEnvironment()
        {
            try
            {
                string fileName = ".env";
                string path = fileName;
                while (!File.Exists(path) && !(Path.GetFullPath(path) == Path.GetPathRoot(Path.GetFullPath(path)) + fileName))
                {
                    Console.WriteLine("Full Path: " + Path.GetFullPath(path));
                    Console.WriteLine("Root Path: " + Path.GetPathRoot(Path.GetFullPath(path)) + fileName);
                    path = "../" + path;
                }
                Env.Load(path);
            }
            catch
            {
                Console.WriteLine("ERROR: Failed to find .env!");
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            LoadEnvironment();
            string envDBType = Environment.GetEnvironmentVariable("DB_TYPE") ?? "";

            if (!optionsBuilder.IsConfigured)
            {
                if (envDBType.Trim().ToLower() == "mariadb" || envDBType.Trim().ToLower() == "mysql")
                {
                    optionsBuilder.UseMySql($"Server={Environment.GetEnvironmentVariable("DB_HOST") ?? ""};" +
                        $"Port=3306;" +
                        $"Database={Environment.GetEnvironmentVariable("DB_NAME") ?? ""};UID=root;PWD=;", new MariaDbServerVersion("10.4.28-MariaDB"));
                }
                else if (envDBType.Trim().ToLower() == "postgres")
                {
                    optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=postgres;UID=postgres;PWD=password");
                }
                else
                {
                    string dbName = Environment.GetEnvironmentVariable("DB_NAME") + ".db";
                    string exactPath = Path.Combine(Directory.GetCurrentDirectory(), dbName);
                    if (!File.Exists(exactPath))
                    {
                        File.Create(exactPath).Close();
                    }
                    optionsBuilder.UseSqlite($"Filename={dbName};");
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
            });

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}