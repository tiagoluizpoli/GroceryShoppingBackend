using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Web.Extensions
{
    public static class CorsExtensions
    {
        private static readonly string AllowSpecificOrigins = "_allowSpecificOrigins";
        public static IServiceCollection AddCorsConfigured(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins, policy =>
                {
                    policy.
                    AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            return services;
        }

        public static IApplicationBuilder UseCorsConfigured(this IApplicationBuilder app)
        {
            app.UseCors(AllowSpecificOrigins);
            return app;
        }
    }
}
