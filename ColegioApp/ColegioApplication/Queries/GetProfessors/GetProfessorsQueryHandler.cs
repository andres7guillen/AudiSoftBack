using ColegioDomain.Entities.Business;
using MediatR;
using SchoolApplication.Helpers;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetProfessors;

public class GetProfessorsQueryHandler
    : IRequestHandler<GetProfessorsQuery, PagedResult<Professor>>
{
    private readonly IProfessorRepository _repository;

    public GetProfessorsQueryHandler(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<PagedResult<Professor>> Handle(
        GetProfessorsQuery request,
        CancellationToken cancellationToken)
    {
        var (items, total) = await _repository.GetPaged(
            request.Page,
            request.PageSize);

        return new PagedResult<Professor>
        {
            Items = items,
            TotalCount = total,
            Page = request.Page,
            PageSize = request.PageSize
        };
    }
}
