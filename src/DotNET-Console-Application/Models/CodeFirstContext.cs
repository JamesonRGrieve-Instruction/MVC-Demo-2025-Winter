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
            // Define seed data for testing or system functionality.
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
            // Define the context of the relationship between this entity and the child entity.
            entity.HasOne(child => child.Instructor).WithMany(parent => parent.Courses).OnDelete(DeleteBehavior.SetNull).HasConstraintName($"FK_{nameof(Course)}_{nameof(Instructor)}");
            // Define the index for the above relationship.
            entity.HasIndex(e => e.InstructorID).HasDatabaseName($"FK_{nameof(Course)}_{nameof(Instructor)}");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            // Define the context of the relationship between this entity and the child entity.
            entity.HasOne(child => child.Course).WithMany(parent => parent.Students).OnDelete(DeleteBehavior.SetNull).HasConstraintName($"FK_{nameof(Student)}_{nameof(Course)}");
            // Define the index for the above relationship.
            entity.HasIndex(e => e.CourseID).HasDatabaseName($"FK_{nameof(Student)}_{nameof(Course)}");
        });
        modelBuilder.Entity<Instructor>();
        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
