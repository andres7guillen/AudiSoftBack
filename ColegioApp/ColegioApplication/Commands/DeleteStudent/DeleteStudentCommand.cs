using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.DeleteStudent;

public record DeleteStudentCommand(Guid Id) : IRequest<Result<bool>>;
