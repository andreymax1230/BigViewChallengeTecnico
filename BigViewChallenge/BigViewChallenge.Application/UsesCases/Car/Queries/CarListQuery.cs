using BigViewChallenge.Application.Mapper;
using BigViewChallenge.Application.Model;
using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using MediatR;
using System.Collections.Generic;

namespace BigViewChallenge.Application.UsesCases.Car.Queries;

public class CarListQuery : IRequest<ResponseDTO>
{
    public Guid UserId { get; set; }
}

public sealed class CarListQueryHandler(IRepository<BigViewChallenge.Domain.Entities.Car> _carRepository) : IRequestHandler<CarListQuery, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(CarListQuery request, CancellationToken cancellationToken)
    {
        var list = _carRepository.GetMany(x => x.UserId == request.UserId);
        var response = MapperConfig.Mapper.Map<List<CarDto>>(list);
        return await Task.FromResult(new ResponseDTO() { Data = response, Success = true });
    }
}