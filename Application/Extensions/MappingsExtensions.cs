using System.Reflection;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class MappingsExtensions
{
    public static IServiceCollection AddMappingsConfigured(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.Load(nameof(Application)));

        services.AddSingleton(config);

        services.AddScoped<IMapper, ServiceMapper>();
        
        return services;
    }
}