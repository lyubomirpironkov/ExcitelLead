using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Infrastructure.Persistence.EF;
using ExcitelLead.Infrastructure.Persistence.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(configuration.GetConnectionString("DefaultConnectionRedis")));

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            services.AddScoped<IUnitOfWorkEF, UnitOfWorkEF>();
            services.AddSingleton<IUnitOfWorkRedis>(serviceProvider =>
                new UnitOfWorkRedis(serviceProvider.GetRequiredService<IConnectionMultiplexer>()));

            return services;
        }
    }
}
