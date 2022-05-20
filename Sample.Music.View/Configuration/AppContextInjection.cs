using Microsoft.EntityFrameworkCore;
using Sample.Music.Model;

namespace Sample.Music.View.Configuration
{
    public static class AppContextInjection
    {
        public static IServiceCollection AddDbContextInjection(this IServiceCollection services, IConfiguration configuration)
        {
            try
            {
                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseMySql(configuration.GetConnectionString("AppDbContext"), MySqlServerVersion.LatestSupportedServerVersion);
#if DEBUG
                    options.EnableSensitiveDataLogging();
                    options.EnableDetailedErrors();
#endif
                });
                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}