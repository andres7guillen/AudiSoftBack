using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetProfessorById;

public class GetProfessorByIdQueryHandler : IRequestHandler<GetProfessorByIdQuery,Maybe<Professor>>
{
    private readonly IProfessorRepository _repository;

    public GetProfessorByIdQueryHandler(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Maybe<Professor>> Handle(GetProfessorByIdQuery request,CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
