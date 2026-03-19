using MediatR;
using SchoolApplication.DTOs;
using SchoolApplication.Helpers;

namespace SchoolApplication.Queries.GetGrades;

public record GetGradesQuery(int Page, int PageSize) : IRequest<PagedResult<GradeDTO>>;
