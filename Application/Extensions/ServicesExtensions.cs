using Application.Services.Implementations;
using Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServicesExtensions
{
    public static IServiceCollection AddServicesConfigured(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IProductService, ProductService>();
        return services;
    }
}