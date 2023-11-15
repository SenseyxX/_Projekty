using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application;
using Warehouse.Domain;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Messaging;
using Warehouse.Infrastructure.Persistence;
using Warehouse.Infrastructure.Persistence.EntitiesConfiguration;

namespace Warehouse.Api
{
    public sealed class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .RegisterDomainDependencies()
                .RegisterApplicationDependencies(_configuration)
                .RegisterInfrastructureDependencies(_configuration);
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseMigrationsOfContext()
                .UseSwaggerMiddleware(_configuration)
                .UseRouting()
                .UseCorsMiddleware()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(builder => builder.MapControllers());

    }
}
