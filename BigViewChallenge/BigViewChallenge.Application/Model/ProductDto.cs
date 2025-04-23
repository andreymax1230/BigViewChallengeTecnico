using BigViewChallenge.Domain.Entities;

namespace BigViewChallenge.Application.Model;

public class ProductDto : BaseEntity
{
    public string Name { get; set; } = "";
    public string Description { get; set; } = "";
    public decimal Price { get; set; }
    public string ImageUrl { get; set; }
    public bool Active { get; set; }
}
