using BigViewChallenge.Application.Model;
using BigViewChallenge.Application.UsesCases.Car.Queries;
using BigViewChallenge.Application.UsesCases.User.Queries;
using BigViewChallenge.Domain.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BigViewChallenge.Api.Controllers;

/// <summary>
/// Controller Class for Module Task
/// </summary>
/// <param name="_mediator"></param>
[Authorize]
[SwaggerTag("(Usuarios)")]
public class UserController(IMediator _mediator) : ApiBaseController(_mediator)
{
    [HttpGet]
    public async Task<ActionResult<ResponseDTO>> Get()
    {
        var result = await Mediator.Send(new UserListQuery() { });
        return Ok(result);
    }
}