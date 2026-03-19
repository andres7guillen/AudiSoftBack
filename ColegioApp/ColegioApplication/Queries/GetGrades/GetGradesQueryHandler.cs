using MediatR;
using SchoolApplication.DTOs;
using SchoolApplication.Helpers;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetGrades;

public class GetGradesQueryHandler : IRequestHandler<GetGradesQuery, PagedResult<GradeDTO>>
{
    private readonly IGradeRepository _repository;

    public GetGradesQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<GradeDTO>> Handle(
        GetGradesQuery request,
        CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetPaged(
            request.Page,
            request.PageSize);
        var itemsGradeResult = items.Select(g => new GradeDTO
        {
            Id = g.Id,
            Name = g.Name,
            ProfessorId = g.ProfessorId.ToString(),
            ProfessorName = g.Professor.Name,
            StudentId = g.StudentId.ToString(),
            StudentName = g.Student.Name,
            Value = g.Value
        }).ToList();

        return new PagedResult<GradeDTO>
        {
            Items = itemsGradeResult,
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
