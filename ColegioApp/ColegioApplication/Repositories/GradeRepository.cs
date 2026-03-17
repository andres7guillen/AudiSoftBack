using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolData.Context;
using SchoolDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly SchoolDbContext _context;

    public GradeRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Grade>> AddAsync(Grade grade)
    {
        await _context.Grades.AddAsync(grade);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(grade)
            : Result.Failure<Grade>("Failed to add grade.");
    }

    public async Task<Result<bool>> AnyByProfessorId(Guid professorId)
    {
        return await _context.Grades.AnyAsync(g => g.ProfessorId == professorId)
            ? Result.Success(true)
            : Result.Success(false);
    }

    public async Task<Result<bool>> AnyByStudentId(Guid studentId)
    {
        return await _context.Grades.AnyAsync(g => g.StudentId == studentId)
            ? Result.Success(true)
            : Result.Success(false);
    }

    public async Task<Result<bool>> DeleteAsync(Grade grade)
    {
        _context.Grades.Remove(grade);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to delete grade.");
    }

    public async Task<Result<IEnumerable<Grade>>> GetAllAsync()
    {
        var grades = _context.Grades.AsNoTracking().ToList();
        return grades.Any()
            ? Result.Success<IEnumerable<Grade>>(grades)
            : Result.Failure<IEnumerable<Grade>>("No grades found.");
    }

    public async Task<Maybe<Grade>> GetByIdAsync(Guid id)
    {
        var grade = await _context.Grades.FindAsync(id);
        return grade == null
            ? Maybe.None
            : Maybe.From(grade);
    }

    public async Task<Result<bool>> UpdateAsync(Grade grade)
    {
        _context.Grades.Update(grade);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to update grade.");
    }
}
