using AutoMapper;

namespace BigViewChallenge.Application.Mapper;

/// <summary>
/// Mapper config for entitoes DB and Commands o Queries results
/// </summary>
internal class MapperConfig
{
    private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<MappingCar>();
            cfg.AddProfile<MappingUser>();
            cfg.AddProfile<MappingProduct>();
        });
        var mapper = config.CreateMapper();
        return mapper;
    });

    public static IMapper Mapper => Lazy.Value;
}