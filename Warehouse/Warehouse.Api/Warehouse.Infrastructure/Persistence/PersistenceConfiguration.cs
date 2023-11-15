using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Persistence
{
    public static class PersistenceConfiguration
    {
        private const string WarehouseContextSectionKey = "WarehouseContext";

        public static IServiceCollection RegisterPersistenceConfiguration(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
            => serviceCollection.AddDbContext<WarehouseContext>(
                options => options.UseSqlServer(
                    configuration.GetConnectionString(WarehouseContextSectionKey),
                    migrationsConfiguration => migrationsConfiguration.MigrationsAssembly(
                        Assembly.GetExecutingAssembly().FullName)));

        public static IApplicationBuilder UseMigrationsOfContext(
            this IApplicationBuilder applicationBuilder)
        {
            using var serviceScope = applicationBuilder
                .ApplicationServices
                .CreateScope();

            var databaseContext = serviceScope
                .ServiceProvider
                .GetService<WarehouseContext>();

            var isInvalid = databaseContext is null;

            if (isInvalid)
            {
                var errorMessage =
                    $"{nameof(InfrastructureConfiguration)}.{nameof(UseMigrationsOfContext)}: {typeof(WarehouseContext).FullName}";

                throw new ArgumentException(errorMessage);
            }

            databaseContext
                .Database
                .Migrate();
            return applicationBuilder;
        }
    }
}
