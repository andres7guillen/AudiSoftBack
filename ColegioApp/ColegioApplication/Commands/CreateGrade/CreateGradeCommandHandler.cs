using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Commands.CreateGrade;

public class CreateGradeCommandHandler
    : IRequestHandler<CreateGradeCommand,Result<Grade>>
{
    private readonly IGradeRepository _repository;

    public CreateGradeCommandHandler(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Grade>> Handle(CreateGradeCommand request,CancellationToken cancellationToken)
    {
        var result = Grade.Create(
            request.Name,
            request.ProfessorId,
            request.StudentId,
            request.Value);

        if (!result.IsSuccess)
            throw new Exception(result.Error);

        return await _repository.AddAsync(result.Value);
    }
}
