using ECommerce.Api.Core.Database.Entities;
using Microsoft.EntityFrameworkCore;
using PIS.Core.Database.Entities;

namespace ECommerce.Api.Core.Database.Extensions;

/// <summary>
/// Contains <see cref="ModelBuilder"/> extension methods with entity configurations.
/// </summary>
internal static class ModelBuilderExtensions
{
    internal static void ConfigureEntities(this ModelBuilder modelBuilder)
        => modelBuilder
        .ConfigureGLPR()
        .ConfigureTypePr()
        .ConfigureStrRozv();

    private static ModelBuilder ConfigureGLPR(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GLPR>()
            .Property(e => e.CdPr)
            .HasColumnType("nvarchar(5)");

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

    private static ModelBuilder ConfigureStrRozv(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StrRozv>()
            .Property(e => e.CdVyr)
            .HasColumnType("nvarchar(5)");

        modelBuilder.Entity<StrRozv>()
            .Property(e => e.CdSb)
            .HasColumnType("nvarchar(5)");

        modelBuilder.Entity<StrRozv>()
            .Property(e => e.CdKp)
            .HasColumnType("nvarchar(5)");

        return modelBuilder;
    }
}
