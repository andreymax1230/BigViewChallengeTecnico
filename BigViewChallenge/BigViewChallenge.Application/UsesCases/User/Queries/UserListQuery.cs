using BigViewChallenge.Application.Mapper;
using BigViewChallenge.Application.Model;
using BigViewChallenge.Domain.Base;
using BigViewChallenge.Domain.Repositories;
using MediatR;

namespace BigViewChallenge.Application.UsesCases.User.Queries;

public class UserListQuery : IRequest<ResponseDTO>
{
}

public sealed class UserListQueryHandler(IRepository<Domain.Entities.User> _userRepository) : IRequestHandler<UserListQuery, ResponseDTO>
{
    public async Task<ResponseDTO> Handle(UserListQuery request, CancellationToken cancellationToken)
    {
        var list = _userRepository.GetAll();
        var response = MapperConfig.Mapper.Map<List<UserDto>>(list);
        return await Task.FromResult(new ResponseDTO() { Data = response, Success = true });
    }
}
