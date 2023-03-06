﻿using Domain.EFSetup;
using Infrastructure.DependencyExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureConfigured( this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseConfigured(configuration);
            services.AddRepositoriesConfigured();

            return services;
        }
    }
}
