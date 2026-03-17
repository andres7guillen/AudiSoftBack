using CSharpFunctionalExtensions;

namespace ColegioDomain.Entities.Business;

public class Student
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }

    private Student() { }

    private Student(Guid id, string name)
    {
        Id = id;
        Name = name;
    }

    public static Result<Student> Create(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Student>("Name is required");
        var student = new Student(Guid.NewGuid(), name);
        return Result.Success(student);
    }

    public Result<bool> UpdateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<bool>("Name invalid");
        Name = name;
        return Result.Success(true);
    }
}
