using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigViewChallenge.Infraestructure.Configuration;

internal class CarConfiguration : IEntityTypeConfiguration<Domain.Entities.Car>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Car> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(Domain.Entities.Car)));
        builder.Property(c => c.UserId).IsRequired();
        builder.Property(c => c.ProductId).IsRequired();
    }
}
