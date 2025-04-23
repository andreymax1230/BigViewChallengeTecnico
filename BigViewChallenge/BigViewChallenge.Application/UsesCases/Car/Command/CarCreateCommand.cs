using BigViewChallenge.Application.Mapper;
using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using BigViewChallenge.Domain.UnitOfWork;
using MediatR;

namespace BigViewChallenge.Application.UsesCases.Car.Command;

public class CarCreateCommand : IRequest<ResponseDTO>
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}

public sealed class CarCreateCommandHandler(IRepository<BigViewChallenge.Domain.Entities.Car> _carRepository,
                                            IUnitOfWork _unitOfWork) : IRequestHandler<CarCreateCommand, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(CarCreateCommand request, CancellationToken cancellationToken)
    {
        var entity = MapperConfig.Mapper.Map<Domain.Entities.Car>(request);
        if (entity is null)
            throw new ApplicationException("There is a problem in mapper");
        entity.CreatedAt = DateTime.Now;
        entity.UpdatedAt = DateTime.Now;
        _carRepository.Insert(entity);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return await Task.FromResult(new ResponseDTO() { Data = entity.Id, Success = response > 0});
    }
}
