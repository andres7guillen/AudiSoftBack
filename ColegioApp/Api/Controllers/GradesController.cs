using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Commands.CreateGrade;
using SchoolApplication.Commands.DeleteGrade;
using SchoolApplication.Commands.UpdateGrade;
using SchoolApplication.Queries.GetGradeById;
using SchoolApplication.Queries.GetGrades;

namespace SchoolApi.Controllers;

[ApiController]
[Route("api/grades")]
public class GradesController : ControllerBase
{
    private readonly IMediator _mediator;

    public GradesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateGradeCommand command)
    {
        var result = await _mediator.Send(command);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateGradeCommand command)
    {
        var result = await _mediator.Send(command);

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteGradeCommand(id));

        return result.IsSuccess
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var grade = await _mediator.Send(new GetGradeByIdQuery(id));

        return grade.HasValue
            ? Ok(grade.Value)
            : NotFound("Grade not found");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetGradesQuery(page, pageSize));

        return Ok(result);
    }
}
