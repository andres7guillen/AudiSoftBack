using CSharpFunctionalExtensions;

namespace ColegioDomain.Entities.Business;

public class Grade
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public Guid StudentId { get; private set; }
    public virtual Student Student { get; private set; }

    public Guid ProfessorId { get; private set; }
    public virtual Professor Professor { get; private set; }

    public double Value { get; private set; }

    private Grade() { }

    private Grade(Guid id, string name, Guid professorId, Guid studentId, double value)
    {
        Id = id;
        Name = name;
        ProfessorId = professorId;
        StudentId = studentId;
        Value = value;
    }

    public static Result<Grade> Create(
        string name,
        Guid professorId,
        Guid studentId,
        double value)
    {
        if (value < 0 || value > 5)
            return Result.Failure<Grade>("Invalid grade value");

        var grade = new Grade(
            Guid.NewGuid(),
            name,
            professorId,
            studentId,
            value);

        return Result.Success<Grade>(grade);
    }

    public void Update(string name, Guid professorId, Guid studentId, double value)
    {
        Name = name;
        ProfessorId = professorId;
        StudentId = studentId;
        Value = value;
    }

    public Result<bool> UpdateValue(double value)
    {
        if (value < 0 || value > 5)
            return Result.Failure<bool>("Invalid value");

        Value = value;

        return Result.Success<bool>(true);
    }
}
