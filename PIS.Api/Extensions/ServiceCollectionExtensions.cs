using ECommerce.Api.Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PIS.Core.Repositories.GLPRs;
using PIS.Core.Repositories.Specs;

namespace ECommerce.Api.Extensions;

/// <summary>
/// Service collection extensions.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Configures Swagger.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(e =>
        {
            e.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "PIS API",
                Version = "v1"
            });

            string filePath = Path.Combine(AppContext.BaseDirectory, "PIS.Api.xml");
            e.IncludeXmlComments(filePath);
            e.DescribeAllParametersInCamelCase();
        });

        return services;
    }

    /// <summary>
    /// Configures DbContext.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <param name="configuration">Configuration.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(e => e.UseSqlServer(configuration.GetValue<string>("Database_ConnectionString")));

    /// <summary>
    /// Adds repositories to DI container.
    /// </summary>
    /// <param name="services">Service collection.</param>
    /// <returns>Service collection.</returns>
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ITypePrsRepository, TypePrsRepository>();
        services.AddScoped<IGLPRsRepository, GLPRsRepository>();
        services.AddScoped<ISpecsRepository, SpecsRepository>();

        return services;
    }
}
