using ColegioDomain.Entities.Business;
using MediatR;
using SchoolApplication.Helpers;

namespace SchoolApplication.Queries.GetGrades;

public record GetGradesQuery(int Page, int PageSize) : IRequest<PagedResult<Grade>>;
