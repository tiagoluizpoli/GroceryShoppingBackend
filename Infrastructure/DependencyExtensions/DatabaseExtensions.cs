using Domain.EFSetup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyExtensions
{
    public static class DatabaseExtensions
    {
        public static IServiceCollection AddDatabaseConfigured(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFDbContext>(options =>

                options.UseNpgsql(configuration.GetSection("AppSettings")["ConnectionString"],
                    options => options.MigrationsAssembly("Api")));
            return services;
        }
    }
}
