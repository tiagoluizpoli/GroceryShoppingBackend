using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ValidationExtensions
{
    public static IServiceCollection AddValidationsConfigured(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.Load(nameof(Application)));
        return services;
    }
}