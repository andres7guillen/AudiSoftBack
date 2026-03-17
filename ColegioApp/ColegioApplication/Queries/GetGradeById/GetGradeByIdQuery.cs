using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Queries.GetGradeById;

public record GetGradeByIdQuery(Guid Id) : IRequest<Maybe<Grade>>;
