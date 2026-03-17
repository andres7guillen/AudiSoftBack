using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApplication.Commands.UpdateProfessor;

public class UpdateProfessorCommandHandler
    : IRequestHandler<UpdateProfessorCommand, Result<bool>>
{
    private readonly IProfessorRepository _repository;

    public UpdateProfessorCommandHandler(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<bool>> Handle(
        UpdateProfessorCommand request,
        CancellationToken cancellationToken)
    {
        var professor = await _repository.GetByIdAsync(request.Id);

        if (professor == null)
            throw new Exception("Professor not found");

        var result = professor.Value.UpdateName(request.Name);

        if (!result.IsSuccess)
            throw new Exception(result.Error);

        return await _repository.UpdateAsync(professor.Value);
    }
}
