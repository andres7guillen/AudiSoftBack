using ColegioDomain.Entities.Business;
using Microsoft.EntityFrameworkCore;

namespace SchoolData.Context;

public class SchoolDbContext : DbContext
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Professor> Professors { get; set; }
    public DbSet<Grade> Grades { get; set; }

    public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Professor>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Grade>()
            .HasKey(x => x.Id);

        modelBuilder.Entity<Grade>()
            .HasOne<Student>()
            .WithMany()
            .HasForeignKey(x => x.StudentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Grade>()
            .HasOne<Professor>()
            .WithMany()
            .HasForeignKey(x => x.ProfessorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
