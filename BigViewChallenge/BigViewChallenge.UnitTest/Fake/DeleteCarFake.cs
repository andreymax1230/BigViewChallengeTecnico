using Bogus;
using BigViewChallenge.Application.UsesCases.Car.Command;

namespace BigViewChallenge.UnitTest.Fake;

/// <summary>
/// Generate Mock fake for Delete task test
/// </summary>
internal static class DeleteTaskFake
{
    public static CarDeleteCommand GenerateItemFake(this Faker<CarDeleteCommand> item)
    {
        item.RuleFor(x => x.Id, z => Guid.NewGuid());
        return item.Generate();
    }
}
