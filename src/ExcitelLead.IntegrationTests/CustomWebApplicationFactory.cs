using ExcitelLead.Infrastructure.Persistence.EF;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace ExcitelLead.IntegrationTests
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration(configurationBuilder =>
            {
                var integrationConfig = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .AddEnvironmentVariables()
                    .Build();

                configurationBuilder.AddConfiguration(integrationConfig);
            });

            builder.ConfigureServices((builder, services) =>
            {
                //services
                //    .Remove<DbContextOptions<AppDbContext>>()
                //    .AddDbContext<AppDbContext>((sp, options) =>
                //        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                //            builder => builder.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
                services
                    .Remove<DbContextOptions<AppDbContext>>()
                    .AddDbContext<AppDbContext>(options =>
                        options.UseInMemoryDatabase((new Guid()).ToString()));

                //services
                //    .Remove<ILeadRepository>()
                //    .AddTransient(provider => Mock.Of<ILeadRepository>());

                //services
                //    .Remove<IUnitOfWork>()
                //    .AddTransient(provider => Mock.Of<IUnitOfWork>());                
            });
        }
    }
}
