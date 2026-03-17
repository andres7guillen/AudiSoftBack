using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetGradeById;

public class GetGradeByIdQueryHandler
    : IRequestHandler<GetGradeByIdQuery, Maybe<Grade>>
{
    private readonly IGradeRepository _repository;

    public GetGradeByIdQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Maybe<Grade>> Handle(
        GetGradeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var grade = await _repository.GetByIdAsync(request.Id);
        if (grade == null)
            throw new Exception("Grade not found");

        return grade;
    }
}
