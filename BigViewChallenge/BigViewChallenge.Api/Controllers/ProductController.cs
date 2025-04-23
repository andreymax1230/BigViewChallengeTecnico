using BigViewChallenge.Application.UsesCases.Car.Queries;
using BigViewChallenge.Application.UsesCases.Product.Queries;
using BigViewChallenge.Domain.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace BigViewChallenge.Api.Controllers;


[Authorize]
[SwaggerTag("(Productos)")]
public class ProductController(IMediator _mediator) : ApiBaseController(_mediator)
{
    [HttpGet]
    public async Task<ActionResult<ResponseDTO>> Get()
    {
        var result = await Mediator.Send(new ProductListQuery() { });
        return Ok(result);
    }
}
