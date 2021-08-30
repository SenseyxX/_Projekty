using Microsoft.Extensions.DependencyInjection;
using Warehouse.Application.Services;

namespace Warehouse.Infrastructure.Services
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection RegisterServicesDependencies(this IServiceCollection serviceCollection)
        => serviceCollection
            .AddTransient<IEncryptionService, EncryptionService>()
            .AddTransient<ITokenService, TokenService>();
    }
}
