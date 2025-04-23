using Bogus;
using BigViewChallenge.Application.Model;

namespace BigViewChallenge.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for get list Task
/// </summary>
internal static class ListTaskFake
{
    public static List<CarDto> ListTaskFaker(this Faker<CarDto> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        item.RuleFor(x => x.UserId, z => Guid.NewGuid());
        item.RuleFor(x => x.ProductId, z => Guid.NewGuid());
        item.RuleFor(x => x.Count, z => 30);
        item.RuleFor(x => x.CreatedAt, z => DateTime.UtcNow);
        item.RuleFor(x => x.UpdatedAt, z => DateTime.UtcNow);
        return item.Generate(6).ToList();
    }
}
