namespace BigViewChallenge.Domain.Entities;

public class Car : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    public virtual User User { get; set; }
    public virtual Product Product { get; set; }    
}
