using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.UpdateProfessor;

public record UpdateProfessorCommand(Guid Id,string Name) : IRequest<Result<bool>>;
