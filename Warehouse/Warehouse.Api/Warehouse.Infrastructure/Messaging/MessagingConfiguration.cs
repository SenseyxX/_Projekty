using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Warehouse.Infrastructure.Messaging.Authorization;

namespace Warehouse.Infrastructure.Messaging
{
    public static class MessagingConfiguration
    {
        public static IServiceCollection RegisterMessagingDependencies(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .RegisterAuthorizationDependencies()
                .ConfigureSwagger(configuration)
                .AddControllers(options => options.Filters.Add<ExceptionFilter>())
                .AddNewtonsoftJson(
                    options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .Services;
    }
}
