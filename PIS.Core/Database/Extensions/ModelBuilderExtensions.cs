using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Api.Core.Database.Extensions;

/// <summary>
/// Contains <see cref="ModelBuilder"/> extension methods with entity configurations.
/// </summary>
internal static class ModelBuilderExtensions
{
    internal static void ConfigureEntities(this ModelBuilder modelBuilder)
        => modelBuilder
        .ConfigureGLPR()
        .ConfigureTypePr();

    private static ModelBuilder ConfigureGLPR(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GLPR>()
            .Property(e => e.NmPr)
            .HasColumnType("nvarchar(150)");

        return modelBuilder;
    }

    private static ModelBuilder ConfigureTypePr(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TypePr>()
            .Property(e => e.NmTp)
            .HasColumnType("nvarchar(150)");

        return modelBuilder;
    }
}
