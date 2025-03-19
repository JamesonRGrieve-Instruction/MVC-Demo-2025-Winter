using DotNET_Console_Application.Models;
using Microsoft.EntityFrameworkCore;

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
    public DbSet<Student> Students { get; }
    public DbSet<Course> Courses { get; }
    public DbSet<Instructor> Instructors { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasData([new Course()
            {
                ID = -1,
                Name = "Introduction to Programming",
                Code = "COMP101"
            }, new Course()
            {
                ID = -2,
                Name = "Introduction to Databases",
                Code = "DATA101"
            }]);
        });
        modelBuilder.Entity<Student>();
        modelBuilder.Entity<Instructor>();
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
