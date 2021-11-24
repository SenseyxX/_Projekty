using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Infrastructure.Messaging;
using Warehouse.Infrastructure.Persistence;
using Warehouse.Infrastructure.Repositories;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Infrastructure
{
    public static class InfrastructureConfiguration // Klasa w któej definiujemy ustawienia solucji persistance
    {
        public static IServiceCollection RegisterInfrastructureDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            return serviceCollection
                .RegisterPersistenceConfiguration(configuration)
                .RegisterRepositoriesDependencies()
                .RegisterMessagingDependencies(configuration)
                .RegisterServicesDependencies();
        }
    }
}
