using ColegioDomain.Entities.Business;
using MediatR;
using SchoolApplication.Helpers;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetGrades;

public class GetGradesQueryHandler
    : IRequestHandler<GetGradesQuery, PagedResult<Grade>>
{
    private readonly IGradeRepository _repository;

    public GetGradesQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Grade>> Handle(
        GetGradesQuery request,
        CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetPaged(
            request.Page,
            request.PageSize);

        return new PagedResult<Grade>
        {
            Items = items,
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
