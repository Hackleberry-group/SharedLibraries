using Microsoft.AspNetCore.Hosting;
using Sentry;

namespace HackleberryExceptions;

public static class WebHostBuilderExtensions
{
    public static IWebHostBuilder HackleBerryExceptionsTraceable(this IWebHostBuilder webHostBuilder, string dsn)
    {
        return webHostBuilder.UseSentry(options =>
        {
            options.Dsn = dsn;
            options.Debug = true; // Enable Sentry debug mode for better troubleshooting during development
        });
    }
}
