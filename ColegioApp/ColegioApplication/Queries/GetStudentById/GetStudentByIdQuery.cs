using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Queries.GetStudentById;

public record GetStudentByIdQuery(Guid Id) : IRequest<Maybe<Student>>;
