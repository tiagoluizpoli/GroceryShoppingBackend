using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using ILogger = Serilog.ILogger;

namespace Infrastructure.DependencyExtensions;

public static class LoggingExtensions
{
    public static ILogger AddLoggingConfigured(this IServiceCollection services, ILoggingBuilder logging)
    {
        logging.ClearProviders();
        ILogger logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        logging.AddSerilog(logger);
        services.AddSingleton(logger);
        return logger;
    }
    
}