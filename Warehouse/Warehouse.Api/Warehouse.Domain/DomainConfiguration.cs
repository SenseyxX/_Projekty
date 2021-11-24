using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Item;
using Warehouse.Domain.Rental;

namespace Warehouse.Domain
{
    public static class DomainConfiguration
    {
        public static IServiceCollection RegisterDomainDependencies(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<ItemDomainService>()
                .AddTransient<RentalDomainService>();
    }
}
