using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;

namespace SchoolDomain.Repositories;

public interface IProfessorRepository
{
    Task<Result<Professor>> AddAsync(Professor Professor);
    Task<Maybe<Professor>> GetByIdAsync(Guid id);
    Task<(IEnumerable<Professor>, int totalCount)> GetPaged(int page, int pageSize);
    Task<Result<bool>> UpdateAsync(Professor professor);
    Task<Result<bool>> DeleteAsync(Professor professor);
}

