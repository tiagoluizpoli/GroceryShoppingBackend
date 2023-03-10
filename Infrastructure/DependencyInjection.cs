using Domain.EFSetup;
using Infrastructure.DependencyExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureConfigured( this IServiceCollection services, IConfiguration configuration, ILoggingBuilder logging)
        {
            services.AddDatabaseConfigured(configuration);
            services.AddRepositoriesConfigured();
            services.AddLoggingConfigured(logging);

            return services;
        }
    }
}
