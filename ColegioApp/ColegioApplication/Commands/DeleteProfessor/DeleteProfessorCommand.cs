using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.DeleteProfessor;

public record DeleteProfessorCommand(Guid Id) : IRequest<Result<bool>>;
