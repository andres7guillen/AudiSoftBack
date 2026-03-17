using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;

namespace SchoolApplication.Commands.UpdateGrade;

public record UpdateGradeCommand(
    Grade grade,
    decimal Value) : IRequest<Result<bool>>;
