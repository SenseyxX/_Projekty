using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application;
using Warehouse.Domain;
using Warehouse.Infrastructure;
using Warehouse.Infrastructure.Messaging;
using Warehouse.Infrastructure.Persistence;

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
                .UseRouting()
                .UseCorsMiddleware()
                .UseAuthentication()
                .UseAuthorization()
                .UseMigrationsOfContext()
                .UseSwaggerMiddleware(_configuration)
                .UseEndpoints(builder => builder.MapControllers());
    }
}
