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
        return await _repository.UpdateAsync(request.grade);
    }
}
