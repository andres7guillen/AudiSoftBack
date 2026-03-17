using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolData.Context;
using SchoolDomain.Repositories;

namespace SchoolApplication.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly SchoolDbContext _context;

    public StudentRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Student>> AddAsync(Student student)
    {
        await _context.Students.AddAsync(student);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(student)
            : Result.Failure<Student>("Failed to add student.");
    }

    public async Task<Result<bool>> DeleteAsync(Student student)
    {
        _context.Students.Remove(student);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to delete student.");
    }

    public async Task<Result<IEnumerable<Student>>> GetAllAsync()
    {
        var students = _context.Students.AsNoTracking().ToList();
        return students.Any()
            ? Result.Success<IEnumerable<Student>>(students)
            : Result.Failure<IEnumerable<Student>>("No students found.");
    }

    public async Task<Maybe<Student>> GetByIdAsync(Guid id)
    {
        var student = await _context.Students.FindAsync(id);
        return student == null
            ? Maybe.None
            : Maybe.From(student);
    }

    public async Task<(IEnumerable<Student>, int totalCount)> GetPaged(int page, int pageSize)
    {
        var query = _context.Students.AsQueryable();

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(x => x.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    public async Task<Result<bool>> UpdateAsync(Student student)
    {
        _context.Students.Update(student);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to update student.");
    }
}
