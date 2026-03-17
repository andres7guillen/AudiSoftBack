using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolApplication.Helpers;

namespace SchoolApplication.Queries.GetStudents;

public record GetStudentsQuery(int Page, int PageSize) : IRequest<PagedResult<Student>>;
