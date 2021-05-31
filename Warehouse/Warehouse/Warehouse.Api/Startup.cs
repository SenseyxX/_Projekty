using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Warehouse.Api.Infrastructure;
using Warehouse.Model;
using Warehouse.Persistence;

namespace Warehouse.Api
{
        public sealed class Startup
        {
                private const string DefaultVersionName = "v1";

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
                        .RegisterModelDependencies()
                        .RegisterPersistenceDependencies(_configuration)
                        .ConfigureSwagger(_configuration);
                }

                public void Configure(IApplicationBuilder app)
                    => app
                        .UseRouting()
                        .UseMigrationsOfContext()
                        .UseSwaggerMiddleware(_configuration)
                        .UseEndpoints(builder => builder.MapControllers());
        }
}
