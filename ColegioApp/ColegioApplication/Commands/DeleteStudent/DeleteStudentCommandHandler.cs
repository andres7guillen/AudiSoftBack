using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.DeleteStudent;

public class DeleteStudentCommandHandler
    : IRequestHandler<DeleteStudentCommand, Result<bool>>
{
    private readonly IStudentRepository _studentRepository;
    private readonly IGradeRepository _gradeRepository;

    public DeleteStudentCommandHandler(
        IStudentRepository studentRepository,
        IGradeRepository gradeRepository)
    {
        _studentRepository = studentRepository;
        _gradeRepository = gradeRepository;
    }

    public async Task<Result<bool>> Handle(
        DeleteStudentCommand request,
        CancellationToken cancellationToken)
    {
        var student = await _studentRepository.GetByIdAsync(request.Id);

        if (student.HasNoValue)
            return Result.Failure<bool>("Student not found");

        var hasGrades = await _gradeRepository.AnyByStudentId(request.Id);

        if (hasGrades.Value)
            return Result.Failure<bool>("Cannot delete student with associated grades");

        return await _studentRepository.DeleteAsync(student.Value);
    }
}
