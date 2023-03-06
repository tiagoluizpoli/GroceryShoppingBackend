using Api.Web.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiWeb(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddCorsConfigured();           

            return services;
        }

        public static IApplicationBuilder UseApiWeb(this IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseStaticFiles();
            app.UseCorsConfigured();

            return app;
        }

    }
}
