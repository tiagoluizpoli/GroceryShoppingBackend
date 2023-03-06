using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;

namespace Application
{
    public  static class DependencyInjection
    {
        public static IServiceCollection AddApplicationConfigured(this IServiceCollection services)
        {

            services.AddMappingsConfigured();

            return services;
        }
    }
}
