using BigViewChallenge.Domain.Entities;

namespace BigViewChallenge.Application.Model;

public class UserDto : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
}
