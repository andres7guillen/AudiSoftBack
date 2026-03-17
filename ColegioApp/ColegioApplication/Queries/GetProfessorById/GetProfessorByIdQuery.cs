using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Queries.GetProfessorById;

public record GetProfessorByIdQuery(Guid Id) : IRequest<Maybe<Professor>>;
