using BigViewChallenge.Domain.Entities;

namespace BigViewChallenge.Application.Model;

/// <summary>
/// Represent data information Task for final user
/// </summary>
public class CarDto : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
    public int Count { get; set; }
}