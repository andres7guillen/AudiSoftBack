using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolApplication.DTOs;
using SchoolDomain.Repositories;

namespace SchoolApplication.Queries.GetGradeById;

public class GetGradeByIdQueryHandler
    : IRequestHandler<GetGradeByIdQuery, Maybe<GradeDTO>>
{
    private readonly IGradeRepository _repository;

    public GetGradeByIdQueryHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Maybe<GradeDTO>> Handle(
        GetGradeByIdQuery request,
        CancellationToken cancellationToken)
    {
        var grade = await _repository.GetByIdAsync(request.Id);
        if (grade.HasNoValue)
            throw new Exception("Grade not found");

        var gradeDto = new GradeDTO
        {
            Id = grade.Value.Id,
            Name = grade.Value.Name,
            ProfessorId = grade.Value.ProfessorId.ToString(),
            ProfessorName = grade.Value.Professor.Name,
            Value = grade.Value.Value,
            StudentId = grade.Value.StudentId.ToString(),
            StudentName = grade.Value.Student.Name
        };
        return Maybe.From(gradeDto);
    }
}
