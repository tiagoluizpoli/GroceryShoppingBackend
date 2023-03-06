using Application.Repositories.Database;
using Infrastructure.Repositories.Database;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyExtensions;

public static class RepositoriesExtensions
{
    public static IServiceCollection AddRepositoriesConfigured(this IServiceCollection services)
    {
        services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
        return services;
    }
}