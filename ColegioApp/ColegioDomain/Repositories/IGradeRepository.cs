using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;

namespace SchoolDomain.Repositories;

public interface IGradeRepository
{
    Task<Result<Grade>> AddAsync(Grade grade);
    Task<Maybe<Grade>> GetByIdAsync(Guid id);
    Task<(IEnumerable<Grade>, int totalCount)> GetPaged(int page, int pageSize);
    Task<Result<bool>> UpdateAsync(Grade grade);
    Task<Result<bool>> DeleteAsync(Grade grade);
    Task<Result<bool>> AnyByStudentId(Guid studentId);
    Task<Result<bool>> AnyByProfessorId(Guid professorId);
}
