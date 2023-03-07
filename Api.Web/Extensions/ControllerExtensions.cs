using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Web.Extensions;

public static class ControllerExtensions
{
    public static IServiceCollection AddControllerConfigured(this IServiceCollection services)
    {
        
        return services;
    }

    public static IApplicationBuilder UseControllerConfigured(this IApplicationBuilder app)
    {
        app.UseRouting();
        app.UseExceptionHandler("/api/Errors/error");
        return app;
    }
}