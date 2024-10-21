using Cqrs.CQRS.Create;
using Cqrs.CQRS.GetAll;
using Cqrs.CQRS.GetById;
using Cqrs.CQRS.Remove;
using Cqrs.CQRS.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cqrs.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
  private readonly IMediator _mediatr;

    public StudentsController(IMediator mediatr)
    {
        _mediatr = mediatr;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result =await _mediatr.Send(new GetByIdQuery(id));

        return Ok(result);
    }
    [HttpGet("GetAll")]
    public IActionResult GetAll()
    {
        var result = _mediatr.Send(new GetAllQuery());

        return Ok(result);
    }
    [HttpPost]
    public IActionResult Create(CreateCommand command)
    {
         _mediatr.Send(command);

        return Ok();
    }
    [HttpDelete("{id}")]
    public IActionResult Remove(int id)
    {
         _mediatr.Send(new RemoveCommand(id));

        return NoContent();
    }
    [HttpPut]
    public IActionResult Update(UpdateCommand command)
    {
         _mediatr.Send(command);
        return NoContent();
    }
}
