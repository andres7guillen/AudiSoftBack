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

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(g => g.Id);

            entity.HasOne(g => g.Professor)
                .WithMany(p => p.Grades)
                .HasForeignKey(g => g.ProfessorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(g => g.Student)
                .WithMany(s => s.Grades)
                .HasForeignKey(g => g.StudentId)
                .OnDelete(DeleteBehavior.Restrict);
        });
    }
}
