using Bogus;
using BigViewChallenge.Application.UsesCases.Car.Command;

namespace BigViewChallenge.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for Create task test
/// </summary>
internal static class PostTaskFake
{
    public static CarCreateCommand GenerateItemFake(this Faker<CarCreateCommand> item)
    {
        item.RuleFor(x => x.UserId, z => Guid.NewGuid());
        item.RuleFor(x => x.ProductId, z => Guid.NewGuid());
        item.RuleFor(x => x.Count, z => 100);
        return item.Generate();
    }
}
