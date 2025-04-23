namespace BigViewChallenge.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
}