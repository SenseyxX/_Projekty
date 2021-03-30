using Microsoft.Extensions.DependencyInjection;
using Warehouse.Model.Services;

namespace Warehouse.Model
{
    public static class ConfigureModel
    {
        public static IServiceCollection RegisterModelDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<IUserService, UserService>();
        }
    }
}
