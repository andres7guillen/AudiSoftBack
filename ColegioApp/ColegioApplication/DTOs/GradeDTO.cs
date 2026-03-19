namespace SchoolApplication.DTOs;

public class GradeDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string StudentId { get; set; } = string.Empty;
    public string StudentName { get; set; } = string.Empty;
    public string ProfessorId { get; set; } = string.Empty;
    public string ProfessorName { get; set; } = string.Empty;
    public double Value { get; set; }
}
