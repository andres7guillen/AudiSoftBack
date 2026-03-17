using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.DeleteGrade;

public class DeleteGradeCommandHandler
    : IRequestHandler<DeleteGradeCommand, Result<bool>>
{
    private readonly IGradeRepository _repository;

    public DeleteGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(
        DeleteGradeCommand request,
        CancellationToken cancellationToken)
    {
        var grade = await _repository.GetByIdAsync(request.Id);

        if (grade == null)
            throw new Exception("Grade not found");

        return await _repository.DeleteAsync(grade.Value);
    }
}
