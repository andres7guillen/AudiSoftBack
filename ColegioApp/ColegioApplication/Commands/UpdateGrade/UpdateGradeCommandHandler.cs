using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.UpdateGrade;

public class UpdateGradeCommandHandler : IRequestHandler<UpdateGradeCommand,Result<bool>>
{
    private readonly IGradeRepository _repository;

    public UpdateGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(
        UpdateGradeCommand request,
        CancellationToken cancellationToken)
    {
        var grade = await _repository.GetByIdAsync(request.Id);
        if (grade.HasNoValue)
            return Result.Failure<bool>("Grade not found");
        grade.Value.Update(request.Name, request.ProfessorId, request.StudentId, request.Value);
        return await _repository.UpdateAsync(grade.Value);
    }
}
