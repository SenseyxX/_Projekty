using System;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Persistence
{
    public static class PersistenceConfiguration
    {
        private const string WarehouseContextSectionKey = "WarehouseContext";

        public static IServiceCollection RegisterPersistenceDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            return serviceCollection
                .AddDbContext<WarehouseContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString(WarehouseContextSectionKey),
                        migrationsConfiguration =>
                            migrationsConfiguration.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName)))
                .RegisterRepositories();
        }

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
                    $"{nameof(PersistenceConfiguration)}.{nameof(UseMigrationsOfContext)}: {typeof(WarehouseContext).FullName}";

                throw new ArgumentException(errorMessage);
            }

            databaseContext
                .Database
                .Migrate();

            return applicationBuilder;
        }

        private static IServiceCollection RegisterRepositories(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IItemRepository, ItemRepository>()
                .AddTransient<ISquadRepository, SquadRepository>();
    }
}
