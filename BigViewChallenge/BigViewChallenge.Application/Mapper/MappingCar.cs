using AutoMapper;

namespace BigViewChallenge.Application.Mapper;

internal class MappingCar : Profile
{
    public MappingCar()
    {
        CreateMap<BigViewChallenge.Domain.Entities.Car, BigViewChallenge.Application.UsesCases.Car.Command.CarCreateCommand>()
            .ReverseMap();
        CreateMap<BigViewChallenge.Domain.Entities.Car, BigViewChallenge.Application.UsesCases.Car.Command.CarUpdateCommand>()
            .ReverseMap();
        CreateMap<BigViewChallenge.Domain.Entities.Car, BigViewChallenge.Application.UsesCases.Car.Command.CarDeleteCommand>()
            .ReverseMap();
        CreateMap<BigViewChallenge.Domain.Entities.Car, BigViewChallenge.Application.Model.CarDto>()
            .ReverseMap();
    }
}
