using BigViewChallenge.Application.Mapper;
using BigViewChallenge.Application.Model;
using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using MediatR;

namespace BigViewChallenge.Application.UsesCases.Product.Queries;

public class ProductListQuery : IRequest<ResponseDTO>
{
}

public sealed class ProductListQueryHandler(IRepository<Domain.Entities.Product> _productRepository) : IRequestHandler<ProductListQuery, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(ProductListQuery request, CancellationToken cancellationToken)
    {
        var list = _productRepository.GetAll();
        var response = MapperConfig.Mapper.Map<List<ProductDto>>(list);
        return await Task.FromResult(new ResponseDTO() { Data = response, Success = true });
    }
}

