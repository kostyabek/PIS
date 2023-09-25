using ECommerce.Api.Core.Database.Entities;
using ECommerce.Api.Core.Database.EntityConfigurations;
using ECommerce.Api.Core.Database.Extensions;
using Microsoft.EntityFrameworkCore;
using PIS.Core.Database.Entities;

namespace ECommerce.Api.Core.Database;

/// <summary>
/// Application DbContext.
/// </summary>
public class AppDbContext : DbContext
{
    public virtual DbSet<GLPR> GLPRs { get; set; }
    public virtual DbSet<TypePr> TypePrs { get; set; }
    public virtual DbSet<Spec> Specs { get; set; }
    public virtual DbSet<StrRozv> StrRozvs { get; set; }

    /// <summary>
    /// Initializes <see cref="AppDbContext"/>.
    /// </summary>
    /// <param name="options">DbContext options.</param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GLPREntityTypeConfiguration).Assembly);

        modelBuilder.ConfigureEntities();
    }
}
