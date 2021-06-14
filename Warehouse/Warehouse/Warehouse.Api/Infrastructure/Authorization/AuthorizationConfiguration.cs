using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Api.Infrastructure.Authorization
{
    public static class AuthorizationConfiguration
    {
        internal static IServiceCollection RegisterAuthorizationDependencies(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceCollection.AddAuthorization(
                options => options.AddPolicy(
                    AuthorizationConstants.AdminRequirementPolicy,
                    policy => policy.Requirements.Add((new AdminRequirement(serviceProvider)))));
        }
    }
}
