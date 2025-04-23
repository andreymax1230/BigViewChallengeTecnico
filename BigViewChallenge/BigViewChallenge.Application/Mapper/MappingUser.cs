namespace BigViewChallenge.Application.Mapper;

internal class MappingUser : AutoMapper.Profile
{
    public MappingUser()
    {
        CreateMap<BigViewChallenge.Domain.Entities.User, BigViewChallenge.Application.Model.UserDto>()
            .ReverseMap();
    }
}
