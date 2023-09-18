using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ECommerce.Api.Core.Database.EntityConfigurations;

/// <summary>
/// Entity type configuration for <see cref="Category"/>.
/// </summary>
internal class GLPREntityTypeConfiguration : IEntityTypeConfiguration<GLPR>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<GLPR> builder)
    {
        builder.HasKey(x => x.CdPr);

        builder.HasOne(e => e.Tp)
            .WithMany()
            .HasForeignKey(e => e.CdTp)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
