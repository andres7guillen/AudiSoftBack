using ColegioDomain.Entities.Business;
using MediatR;
using SchoolApplication.Helpers;

namespace SchoolApplication.Queries.GetProfessors;

public record GetProfessorsQuery(int Page, int PageSize) : IRequest<PagedResult<Professor>>;
