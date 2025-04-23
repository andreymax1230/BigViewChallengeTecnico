using BigViewChallenge.Application.UsesCases.Car.Command;
using BigViewChallenge.Application.UsesCases.Car.Queries;
using BigViewChallenge.Domain.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BigViewChallenge.Api.Controllers;

[Authorize]
[SwaggerTag("(Carrito de Compras)")]
public class CarController(IMediator _mediator) : ApiBaseController(_mediator)
{
    [HttpPost]
    public async Task<ActionResult<ResponseDTO>> Post(CarCreateCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ResponseDTO>> Put(CarUpdateCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult<ResponseDTO>> Delete(CarDeleteCommand model)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var result = await Mediator.Send(model);
        return Ok(result);
    }

    [HttpGet]
    [Route("{userId}")]
    public async Task<ActionResult<ResponseDTO>> Get(Guid userId)
    {
        var result = await Mediator.Send(new CarListQuery() { UserId = userId });
        return Ok(result);
    }
}
