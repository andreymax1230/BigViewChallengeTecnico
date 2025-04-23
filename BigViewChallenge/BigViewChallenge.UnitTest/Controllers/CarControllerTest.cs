using Bogus;
using BigViewChallenge.Api.Controllers;
using BigViewChallenge.Application.Model;
using BigViewChallenge.UnitTest.Fake;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;
using BigViewChallenge.Application.UsesCases.Car.Command;
using BigViewChallenge.Application.UsesCases.Car.Queries;
using BigViewChallenge.Domain.Base;
namespace BigViewChallenge.UnitTest.Controllers;

/// <summary>
/// Class for test methods of TaskController
/// </summary>
[TestFixture]
public class TaskControllerTest
{

    [Fact]
    public async Task Post()
    {
        var request = new Faker<CarCreateCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(new ResponseDTO());
        mediador.Setup(m => m.Send(It.IsAny<CarCreateCommand>(), default(CancellationToken))).Returns(response);
        var controller = new CarController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Post(request)).Result).Value;
        Xunit.Assert.NotNull(response);
    }

    [Fact]
    public async Task Put()
    {
        var request = new Faker<CarUpdateCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(new ResponseDTO());
        mediador.Setup(m => m.Send(It.IsAny<CarUpdateCommand>(), default(CancellationToken))).Returns(response);
        var controller = new CarController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Put(request)).Result).Value;
        Xunit.Assert.NotNull(result);
    }

    [Fact]
    public async Task Delete()
    {
        var request = new Faker<CarDeleteCommand>().GenerateItemFake();
        Mock<IMediator> mediador = new();
        var response = Task.FromResult(new ResponseDTO());
        mediador.Setup(m => m.Send(It.IsAny<CarDeleteCommand>(), default(CancellationToken))).Returns(response);
        var controller = new CarController(mediador.Object);
        var result = ((OkObjectResult)(await controller.Delete(request)).Result).Value;
        Xunit.Assert.NotNull(result);
    }
}
