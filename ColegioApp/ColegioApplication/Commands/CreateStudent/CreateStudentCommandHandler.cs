using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.CreateStudent;

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Result<Student>>
{
    private readonly IStudentRepository _repository;

    public CreateStudentCommandHandler(IStudentRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Student>> Handle(
        CreateStudentCommand request,
        CancellationToken cancellationToken)
    {
        var newStudent = Student.Create(request.Name);

        if (!newStudent.IsSuccess)
            throw new Exception(newStudent.Error);

        var result = await _repository.AddAsync(newStudent.Value);

        return Result.Success(result.Value);
    }
}
