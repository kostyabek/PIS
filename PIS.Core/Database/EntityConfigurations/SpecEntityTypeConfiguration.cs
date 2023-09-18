using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Core.Database.EntityConfigurations;

/// <summary>
/// Entity type configuration for <see cref="Spec"/>.
/// </summary>
internal class SpecEntityTypeConfiguration : IEntityTypeConfiguration<Spec>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<Spec> builder)
    {
        builder.HasKey(e => new { e.CdSb, e.CdKp });

        builder.HasOne(e => e.Sb)
            .WithMany()
            .HasForeignKey(e => e.CdSb)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(e => e.Kp)
            .WithMany()
            .HasForeignKey(e => e.CdKp)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
