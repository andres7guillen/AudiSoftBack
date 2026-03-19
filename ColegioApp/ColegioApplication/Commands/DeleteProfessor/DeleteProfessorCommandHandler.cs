using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.DeleteProfessor;

public class DeleteProfessorCommandHandler : IRequestHandler<DeleteProfessorCommand, Result<bool>>
{
    private readonly IProfessorRepository _professorRepository;
    private readonly IGradeRepository _gradeRepository;

    public DeleteProfessorCommandHandler(
        IProfessorRepository professorRepository,
        IGradeRepository gradeRepository)
    {
        _professorRepository = professorRepository;
        _gradeRepository = gradeRepository;
    }

    public async Task<Result<bool>> Handle(DeleteProfessorCommand request,CancellationToken cancellationToken)
    {
        var professor = await _professorRepository.GetByIdAsync(request.Id);

        if (professor == null)
            throw new Exception("Professor not found");

        var hasGrades = await _gradeRepository.AnyByProfessorId(request.Id);

        if (hasGrades.Value)
            return Result.Failure<bool>("Cannot delete professor with associated grades");

        return await _professorRepository.DeleteAsync(professor.Value);
    }
}
