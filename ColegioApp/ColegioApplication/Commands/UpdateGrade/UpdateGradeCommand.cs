using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.UpdateGrade;

public record UpdateGradeCommand(Guid Id,string Name,Guid ProfessorId,Guid StudentId,double Value) : IRequest<Result<bool>>;
