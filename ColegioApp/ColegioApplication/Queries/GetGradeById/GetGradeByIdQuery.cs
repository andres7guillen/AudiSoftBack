using CSharpFunctionalExtensions;
using MediatR;
using SchoolApplication.DTOs;

namespace SchoolApplication.Queries.GetGradeById;

public record GetGradeByIdQuery(Guid Id) : IRequest<Maybe<GradeDTO>>;
