using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.UpdateStudent;

public class UpdateStudentCommandHandler
    : IRequestHandler<UpdateStudentCommand,Result<bool>>
{
    private readonly IStudentRepository _repository;

    public UpdateStudentCommandHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(
        UpdateStudentCommand request,
        CancellationToken cancellationToken)
    {
        var student = await _repository.GetByIdAsync(request.Id);

        if (student.Value == null)
            throw new Exception("Student not found");

        var result = student.Value.UpdateName(request.Name);

        if (!result.IsSuccess)
            return Result.Failure<bool>(result.Error);

        return await _repository.UpdateAsync(student.Value);
    }
}
