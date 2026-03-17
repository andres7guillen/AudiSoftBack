using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.UpdateStudent;

public record UpdateStudentCommand(
    Guid Id,
    string Name) : IRequest<Result<bool>>;
