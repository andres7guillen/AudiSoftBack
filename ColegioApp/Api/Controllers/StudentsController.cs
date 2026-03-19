using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Commands.CreateStudent;
using SchoolApplication.Commands.DeleteStudent;
using SchoolApplication.Commands.UpdateStudent;
using SchoolApplication.Queries.GetStudentById;
using SchoolApplication.Queries.GetStudents;

namespace SchoolApi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateStudentCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateStudentCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess
            ? NoContent()
            : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteStudentCommand(id));
        return result.IsSuccess 
            ? Ok(result.Value) 
            : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var student = await _mediator.Send(new GetStudentByIdQuery(id));
        return student.HasValue
            ? Ok(student.Value)
            : NotFound("Student not found");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
     [FromQuery] int page = 1,
     [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetStudentsQuery(page, pageSize));

        return result.TotalCount > 0
            ? Ok(result)
            : NotFound("No students found");
    }
}
