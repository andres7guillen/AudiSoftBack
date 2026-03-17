using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolApplication.Helpers;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetStudents;

public class GetStudentsQueryHandler
    : IRequestHandler<GetStudentsQuery, PagedResult<Student>>
{
    private readonly IStudentRepository _repository;

    public GetStudentsQueryHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Student>> Handle(
        GetStudentsQuery request,
        CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetPaged(
            request.Page,
            request.PageSize);

        return new PagedResult<Student>
        {
            Items = items,
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
