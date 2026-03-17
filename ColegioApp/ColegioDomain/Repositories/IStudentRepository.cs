using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;

namespace SchoolDomain.Repositories;

public interface IStudentRepository
{
    Task<Result<Student>> AddAsync(Student student);

    Task<Maybe<Student>> GetByIdAsync(Guid id);
    Task<(IEnumerable<Student>, int totalCount)> GetPaged(int page, int pageSize);
    Task<Result<bool>> UpdateAsync(Student student);

    Task<Result<bool>> DeleteAsync(Student student);
}
