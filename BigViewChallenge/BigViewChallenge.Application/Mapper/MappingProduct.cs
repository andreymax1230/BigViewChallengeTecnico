namespace BigViewChallenge.Application.Mapper;

internal class MappingProduct : AutoMapper.Profile
{
    public MappingProduct()
    {
        CreateMap<BigViewChallenge.Domain.Entities.Product, BigViewChallenge.Application.Model.ProductDto>()
            .ReverseMap();
    }
}
