using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.CreateGrade;

public record CreateGradeCommand(string Name,Guid ProfessorId,Guid StudentId,   double Value) : IRequest<Result<Grade>>;
