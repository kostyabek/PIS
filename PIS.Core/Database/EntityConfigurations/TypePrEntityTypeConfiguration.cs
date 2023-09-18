using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PIS.Core.Enums;

namespace ECommerce.Api.Core.Database.EntityConfigurations;

/// <summary>
/// Entity type configuration for <see cref="TypePr"/>.
/// </summary>
internal class TypePrEntityTypeConfiguration : IEntityTypeConfiguration<TypePr>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<TypePr> builder)
    {
        builder.HasKey(e => e.CdTp);

        builder.HasData(new[]
            {
                new TypePr
                {
                    CdTp = (int)TypePrIds.Product,
                    NmTp = "виріб"
                },
                new TypePr
                {
                    CdTp = (int)TypePrIds.Node,
                    NmTp = "вузол (агрегат, збірка)"
                },
                new TypePr
                {
                    CdTp = (int)TypePrIds.OwnedPart,
                    NmTp = "деталь власного виробництва"
                },
                new TypePr
                {
                    CdTp = (int)TypePrIds.BoughtItem,
                    NmTp = "покупний (комплектувальний) предмет"
                }
            }
        );
    }
}
