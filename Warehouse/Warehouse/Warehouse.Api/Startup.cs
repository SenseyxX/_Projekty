using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Warehouse.Api.Infrastructure;
using Warehouse.Api.Infrastructure.Authorization;
using Warehouse.Model;
using Warehouse.Persistence;

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
                .AddControllers(options => options
                    .Filters
                    .Add<ExceptionFilter>())
                .AddNewtonsoftJson(options =>
                    options
                        .SerializerSettings
                        .ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .Services
                .RegisterModelDependencies(_configuration)
                .RegisterPersistenceDependencies(_configuration)
                .ConfigureSwagger(_configuration)
                .RegisterAuthorizationDependencies();
        }

        public void Configure(IApplicationBuilder app)
            => app
                .UseMigrationsOfContext()
                .UseSwaggerMiddleware(_configuration)
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseEndpoints(builder => builder.MapControllers());
    }
}
