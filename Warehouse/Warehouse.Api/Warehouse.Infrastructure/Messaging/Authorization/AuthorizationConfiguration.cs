using System;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Infrastructure.Messaging.Authorization
{
    public static class AuthorizationConfiguration
    {
        internal static IServiceCollection RegisterAuthorizationDependencies(this IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceCollection
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = "Bearer";
                    options.DefaultChallengeScheme = "Bearer";

                })
                .AddJwtBearer(o =>
                {
                    // ToDo: It should be moved to appSettings and configuration.
                    var secretKey = Encoding.ASCII.GetBytes(TokenService.SecretKey);
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(secretKey),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                })
                .Services
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
