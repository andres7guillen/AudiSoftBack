using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.CreateProfessor;

public record CreateProfessorCommand(string Name) : IRequest<Result<Professor>>;
