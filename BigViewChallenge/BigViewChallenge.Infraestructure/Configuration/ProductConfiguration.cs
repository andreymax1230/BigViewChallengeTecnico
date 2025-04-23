using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigViewChallenge.Infraestructure.Configuration;

internal class ProductConfiguration : IEntityTypeConfiguration<Domain.Entities.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.Product> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(Domain.Entities.Product)));
        builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
        builder.Property(c => c.Description).HasMaxLength(512).IsRequired();
        builder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(c => c.Active).IsRequired();
    }
}
