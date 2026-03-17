using CSharpFunctionalExtensions;

namespace ColegioDomain.Entities.Business;

public class Professor
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Professor() { }

    private Professor(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Result<Professor> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Professor>("Name required");

        var professor = new Professor(Guid.NewGuid(), name);

        return Result.Success<Professor>(professor);
    }

    public Result<bool> UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<bool>("Invalid name");

        Name = name;

        return Result.Success<bool>(true);
    }
}
