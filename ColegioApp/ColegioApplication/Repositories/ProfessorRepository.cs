using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using SchoolData.Context;
using SchoolDomain.Repositories;

namespace SchoolApplication.Repositories;

public class ProfessorRepository : IProfessorRepository
{
    private readonly SchoolDbContext _context;

    public ProfessorRepository(SchoolDbContext context)
    {
        _context = context;
    }

    public async Task<Result<Professor>> AddAsync(Professor Professor)
    {
        await _context.Professors.AddAsync(Professor);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(Professor)
            : Result.Failure<Professor>("Failed to add Professor.");
    }

    public async Task<Result<bool>> DeleteAsync(Professor Professor)
    {
        _context.Professors.Remove(Professor);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to delete Professor.");
    }

    public async Task<Result<IEnumerable<Professor>>> GetAllAsync()
    {
        var Professors = _context.Professors.AsNoTracking().ToList();
        return Professors.Any()
            ? Result.Success<IEnumerable<Professor>>(Professors)
            : Result.Failure<IEnumerable<Professor>>("No Professors found.");
    }

    public async Task<Maybe<Professor>> GetByIdAsync(Guid id)
    {
        var Professor = await _context.Professors.FindAsync(id);
        return Professor == null
            ? Maybe.None
            : Maybe.From(Professor);
    }

    public async Task<(IEnumerable<Professor>, int totalCount)> GetPaged(int page, int pageSize)
    {
        var query = _context.Professors.AsQueryable();

        var totalCount = await query.CountAsync();

        var items = await query
            .OrderBy(x => x.Name)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, totalCount);
    }

    public async Task<Result<bool>> UpdateAsync(Professor Professor)
    {
        _context.Professors.Update(Professor);
        return await _context.SaveChangesAsync() > 0
            ? Result.Success(true)
            : Result.Failure<bool>("Failed to update Professor.");
    }
}
