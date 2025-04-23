using BigViewChallenge.Application.UsesCases.Car.Command;
using Bogus;

namespace BigViewChallenge.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for Update task test
/// </summary>
internal static class PutTaskFake
{
    public static CarUpdateCommand GenerateItemFake(this Faker<CarUpdateCommand> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        item.RuleFor(x => x.UserId, z => Guid.NewGuid());
        item.RuleFor(x => x.ProductId, z => Guid.NewGuid());
        item.RuleFor(x => x.Count, z => 20);
        return item.Generate();
    }
}
