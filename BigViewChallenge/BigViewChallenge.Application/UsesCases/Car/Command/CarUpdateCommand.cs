using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using BigViewChallenge.Domain.UnitOfWork;
using MediatR;

namespace BigViewChallenge.Application.UsesCases.Car.Command;

public class CarUpdateCommand : IRequest<ResponseDTO>
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}

public sealed class CarUpdateCommandHandler(IRepository<BigViewChallenge.Domain.Entities.Car> _carRepository,
                                            IUnitOfWork _unitOfWork) : IRequestHandler<CarUpdateCommand, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(CarUpdateCommand request, CancellationToken cancellationToken)
    {
        var entity = _carRepository.GetById(request.Id);
        if (entity is null)
            throw new ApplicationException("There is a problem in mapper");
        entity.UserId = request.UserId;
        entity.ProductId = request.ProductId;
        entity.Count = request.Count;
        entity.UpdatedAt = DateTime.Now;
        _carRepository.Update(entity);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return await Task.FromResult(new ResponseDTO() { Data = entity.Id, Success = response > 0 });
    }
}