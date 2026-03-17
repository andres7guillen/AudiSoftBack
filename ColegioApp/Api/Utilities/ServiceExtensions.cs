using SchoolApplication.Commands.CreateGrade;
using SchoolApplication.Commands.CreateProfessor;
using SchoolApplication.Commands.CreateStudent;
using SchoolApplication.Commands.DeleteGrade;
using SchoolApplication.Commands.DeleteProfessor;
using SchoolApplication.Commands.DeleteStudent;
using SchoolApplication.Commands.UpdateGrade;
using SchoolApplication.Commands.UpdateProfessor;
using SchoolApplication.Commands.UpdateStudent;
using SchoolApplication.Queries.GetGradeById;
using SchoolApplication.Queries.GetGrades;
using SchoolApplication.Queries.GetProfessorById;
using SchoolApplication.Queries.GetProfessors;
using SchoolApplication.Queries.GetStudentById;
using SchoolApplication.Queries.GetStudents;
using SchoolApplication.Repositories;
using SchoolDomain.Repositories;
using System.Reflection;

namespace Api.Utilities;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
    {
        // Repositorios
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IGradeRepository, GradeRepository>();
        services.AddScoped<IProfessorRepository, ProfessorRepository>();

        // AutoMapper - Registra todos los perfiles
        //services.AddAutoMapper(cfg =>
        //{
        //    cfg.AddProfile<StudentProfile>();
        //    cfg.AddProfile<SubjectProfile>();
        //    cfg.AddProfile<ProfessorProfile>();
        //    cfg.AddProfile<StudentSubjectProfile>();
        //    cfg.AddProfile<ProfessorSubjectProfile>();
        //    cfg.AddProfile<CreditProgramProfile>();
        //    cfg.AddProfile<StudentCreditProgramProfile>();
        //});

        // MeddiatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
            Assembly.GetExecutingAssembly(),
            typeof(CreateProfessorCommand).Assembly,
            typeof(CreateStudentCommand).Assembly,
            typeof(CreateGradeCommand).Assembly,
            typeof(DeleteGradeCommand).Assembly,
            typeof(DeleteProfessorCommand).Assembly,
            typeof(DeleteStudentCommand).Assembly,
            typeof(GetProfessorByIdQuery).Assembly,
            typeof(GetStudentByIdQuery).Assembly,
            typeof(GetGradeByIdQuery).Assembly,
            typeof(GetGradesQuery).Assembly,
            typeof(GetProfessorsQuery).Assembly,
            typeof(GetStudentsQuery).Assembly,
            typeof(UpdateGradeCommand).Assembly,
            typeof(UpdateProfessorCommand).Assembly,
            typeof(UpdateStudentCommand).Assembly
        ));

        return services;
    }
}
