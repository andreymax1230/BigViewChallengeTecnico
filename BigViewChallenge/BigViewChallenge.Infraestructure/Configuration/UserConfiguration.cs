using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigViewChallenge.Infraestructure.Configuration;

/// <summary>
/// Generate Configuration name and fields of table Task
/// </summary>
internal class UserConfiguration : IEntityTypeConfiguration<Domain.Entities.User>
{
    public void Configure(EntityTypeBuilder<Domain.Entities.User> builder)
    {
        builder.ToTable(string.Format("{0}", nameof(Domain.Entities.User)));
        builder.Property(c => c.Name).HasMaxLength(128).IsRequired();
        builder.Property(c => c.Email).HasMaxLength(128).IsRequired();
    }
}