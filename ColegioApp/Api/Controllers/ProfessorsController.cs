using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolApplication.Commands.CreateProfessor;
using SchoolApplication.Commands.DeleteProfessor;
using SchoolApplication.Commands.UpdateProfessor;
using SchoolApplication.Queries.GetProfessorById;
using SchoolApplication.Queries.GetProfessors;

namespace SchoolApi.Controllers;

[ApiController]
[Route("api/professors")]
public class ProfessorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProfessorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateProfessorCommand command)
    {
        var profressorCreated = await _mediator.Send(command);
        if(profressorCreated.IsSuccess)
            return Ok(profressorCreated.Value);
        return BadRequest(profressorCreated.Error);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProfessorCommand command)
    {
        var result = await _mediator.Send(command);
        return result.IsSuccess 
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteProfessorCommand(id));
        return result.IsSuccess 
            ? Ok(result.Value)
            : BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var professor = await _mediator.Send(new GetProfessorByIdQuery(id));
        return professor.HasValue
            ? Ok(professor.Value)
            : NotFound("Professor not found");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(
    [FromQuery] int page = 1,
    [FromQuery] int pageSize = 10)
    {
        var result = await _mediator.Send(
            new GetProfessorsQuery(page, pageSize));

        return result.TotalCount > 0 
            ? Ok(result)
            : NotFound("No professors found");
    }
}
