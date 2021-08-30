using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Application.Handlers
{
    internal static class HandlersConfiguration
    {
        public static IServiceCollection RegisterHandlersDependencies(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddTransient<CategoryHandler>()
            .AddTransient<ItemHandler>()
            .AddTransient<UserHandler>()
            .AddTransient<SquadHandler>()
            .AddTransient<AuthenticationHandler>();
    }
}
