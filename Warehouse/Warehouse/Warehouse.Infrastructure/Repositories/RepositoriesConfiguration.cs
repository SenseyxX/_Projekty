using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.Category;
using Warehouse.Domain.Item;
using Warehouse.Domain.Rental;
using Warehouse.Domain.Squad;
using Warehouse.Domain.User;

namespace Warehouse.Infrastructure.Repositories
{
    public static class RepositoriesConfiguration
    {
        public static IServiceCollection RegisterRepositoriesDependencies(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddTransient<IUserRepository, UserRepository>()
                .AddTransient<ICategoryRepository, CategoryRepository>()
                .AddTransient<IItemRepository, ItemRepository>()
                .AddTransient<ISquadRepository, SquadRepository>()
                .AddTransient<IRentalRepository, RentalRepository>();
    }
}
