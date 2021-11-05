using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Handlers;
using Warehouse.Application.Settings;

namespace Warehouse.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection RegisterApplicationDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
            => serviceCollection
                .RegisterSettingsDependencies(configuration)
                .RegisterHandlersDependencies();
    }
}
