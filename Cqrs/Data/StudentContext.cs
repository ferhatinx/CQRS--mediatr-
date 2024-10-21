using Microsoft.EntityFrameworkCore;

namespace Cqrs.Data;

public class StudentContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public StudentContext(DbContextOptions<StudentContext> db) : base(db)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>().HasData( new List<Student>{
            new Student { Id=1, Name = "Ferhat",Age=25,Number=1},
            new Student { Id=2, Name = "Betül",Age=25,Number=2},
            new Student { Id=3, Name = "Osman",Age=31,Number=3},
        });
        base.OnModelCreating(modelBuilder);
    }
}
