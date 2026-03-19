using ColegioDomain.Entities.Business;
using CSharpFunctionalExtensions;
using MediatR;
using SchoolDomain.Repositories;

namespace SchoolApplication.Commands.CreateProfessor;

public class CreateProfessorCommandHandler : IRequestHandler<CreateProfessorCommand, Result<Professor>>
{
    private readonly IProfessorRepository _repository;

    public CreateProfessorCommandHandler(IProfessorRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<Professor>> Handle(CreateProfessorCommand request,CancellationToken cancellationToken)
    {
        var result = Professor.Create(request.Name);

        if (!result.IsSuccess)
            return Result.Failure<Professor>(result.Error);

        return await _repository.AddAsync(result.Value);
    }
}
