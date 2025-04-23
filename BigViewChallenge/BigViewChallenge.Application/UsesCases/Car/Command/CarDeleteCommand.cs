using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using BigViewChallenge.Domain.UnitOfWork;
using MediatR;

namespace BigViewChallenge.Application.UsesCases.Car.Command;

public class CarDeleteCommand : IRequest<ResponseDTO>
{
    public Guid Id { get; set; }
}

public sealed class CarDeleteCommandHandler(IRepository<BigViewChallenge.Domain.Entities.Car> _carRepository,
                                             IUnitOfWork _unitOfWork) : IRequestHandler<CarDeleteCommand, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(CarDeleteCommand request, CancellationToken cancellationToken)
    {
        var entity = _carRepository.GetById(request.Id);
        if (entity is null)
            throw new ApplicationException("There is a problem in mapper");
        _carRepository.Delete(entity);
        var response = await _unitOfWork.CommitAsync(cancellationToken);
        return await Task.FromResult(new ResponseDTO() { Data = entity.Id, Success = response > 0 });
    }
}
