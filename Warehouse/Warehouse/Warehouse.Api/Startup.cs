using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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
                        services.AddSwaggerGen(c =>
                        {
                                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Mag.Api", Version = DefaultVersionName });
                        });

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
                            .RegisterPersistenceDependencies(_configuration);
                }

                public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                {
                        if (env.IsDevelopment())
                        {
                                app.UseDeveloperExceptionPage();
                        }

                        app.UseRouting()
                            .UseMigrationsOfContext();

                        app.UseEndpoints(endpoints =>
                        {
                                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
                        });
                }
        }
}
