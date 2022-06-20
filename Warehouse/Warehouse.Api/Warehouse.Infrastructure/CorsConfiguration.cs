using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Infrastructure
{
    public static class CorsConfiguration
    {
        private const string AllowedOriginsSectionName = "AllowedOrigins";
        private const string PolicyName = "warehousePolicy";

        public static IServiceCollection RegisterCorsDependencies(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            var originsContainer = configuration
                .GetSection(AllowedOriginsSectionName)
                .Get<ICollection<string>>();

            return services.AddCors(o => o.AddPolicy(
                    PolicyName,
                    b =>
                    {
                        foreach (var origin in originsContainer)
                        {
                            b.WithOrigins(origin)
                                .AllowAnyHeader()
                                .AllowAnyMethod()
                                .AllowCredentials();
                        }
                    }));
         }

        public static IApplicationBuilder UseCorsMiddleware(this IApplicationBuilder applicationBuilder)
            => applicationBuilder.UseCors(PolicyName);
    }
}
