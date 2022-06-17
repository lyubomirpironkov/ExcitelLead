using ExcitelLead.Application.Common.Interfaces;
using ExcitelLead.Infrastructure.Persistence.Common;
using ExcitelLead.Infrastructure.Persistence.EF;
using ExcitelLead.Infrastructure.Persistence.EF.Repositories;
using ExcitelLead.Infrastructure.Persistence.Redis.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add EF db context
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("DefaultConnection"),
                        b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));

            // Add redis connection/db
            services.AddSingleton<IConnectionMultiplexer>(
                ConnectionMultiplexer.Connect(configuration.GetConnectionString("DefaultConnectionRedis")));

            services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

            if (configuration["UseRedis"].ToLower() == "true" )
            {
                services.AddScoped<ILeadRepository>(serviceProvider =>
                    new LeadRepositoryRedis(serviceProvider.GetRequiredService<IConnectionMultiplexer>()));
            }
            else
            {
                services.AddScoped<ILeadRepository>(serviceProvider =>
                    new LeadRepositoryEF(serviceProvider.GetRequiredService<AppDbContext>()));
            }
            
            services.AddScoped<ISubAreaRepository>(serviceProvider =>
                new SubAreaRepositoryEF(serviceProvider.GetRequiredService<AppDbContext>()));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
