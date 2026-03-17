using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.CreateStudent;

public record CreateStudentCommand(string Name) : IRequest<Result<Student>>;
