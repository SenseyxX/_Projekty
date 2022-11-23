using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Item;
using Warehouse.Domain.Item.Factories;
using Warehouse.Domain.Rental;
using Warehouse.Domain.Squad;

namespace Warehouse.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection RegisterDomainDependencies(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<ItemDomainService>()
                .AddTransient<RentalDomainService>()
                .AddTransient<TeamDomainService>()
                .AddTransient<ItemFactory>();
    }
}
