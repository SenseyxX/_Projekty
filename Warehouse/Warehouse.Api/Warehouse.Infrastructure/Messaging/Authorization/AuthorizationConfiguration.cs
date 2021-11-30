﻿using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Infrastructure.Messaging.Authorization
{
    public static class AuthorizationConfiguration
    {
        internal static IServiceCollection RegisterAuthorizationDependencies(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceCollection
                .AddAuthorization(options => options.AddPolicy(
                    AuthorizationConstants.AdminRequirementPolicy,
                    policy => policy.Requirements.Add(new AdminRequirement(serviceProvider))))
                .AddAuthorization(options => options.AddPolicy(
                    AuthorizationConstants.SquadOwnerRequirementPolicy,
                    policy => policy.Requirements.Add(new SquadOwnerRequirement(serviceProvider)))) 
                .AddAuthorization(options => options.AddPolicy(
                    AuthorizationConstants.UserRequirementPolicy,
                    policy=>policy.Requirements.Add(new UserRequirement(serviceProvider))));
        }
    }
}
