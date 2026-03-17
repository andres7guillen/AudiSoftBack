using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.DeleteGrade;

public record DeleteGradeCommand(Guid Id) : IRequest<Result<bool>>;
