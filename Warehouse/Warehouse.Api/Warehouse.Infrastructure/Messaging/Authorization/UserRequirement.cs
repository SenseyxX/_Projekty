using System;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Domain.User;
using Warehouse.Domain.User.Enumeration;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Infrastructure.Messaging.Authorization
{
    public sealed class UserRequirement : AuthorizationHandler<UserRequirement>, IAuthorizationRequirement
    {
        private readonly IServiceProvider _serviceProvider;

        public UserRequirement(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            UserRequirement requirement)
        {
            var isTokenProvided = CheckIsTokenProvided(context);
            var isUser = isTokenProvided && await CheckIsSquadOwnerAsync(context.User);

            if (isUser)
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
        
        private async Task<bool> CheckIsSquadOwnerAsync(ClaimsPrincipal claimsPrincipal)
        {
            var serviceProvider = (ServiceProvider)_serviceProvider;

            var scope = serviceProvider.CreateScope();
            var userRepository = scope.ServiceProvider.GetService<IUserRepository>()
                                 ?? throw new NullReferenceException();

            var userId = GetUserIdClaim(claimsPrincipal);

            var user = await userRepository.GetAsync(userId, CancellationToken.None);
            return user.PermissionLevel == PermissionLevel.User;
        }

        private static bool CheckIsTokenProvided(AuthorizationHandlerContext context) =>
            context
                .User
                .Claims
                .Any();

        private static Guid GetUserIdClaim(ClaimsPrincipal claimsPrincipal)
        {
            var claim = claimsPrincipal.Claims.FirstOrDefault(claim => claim.Type == TokenService.TokenOwnerKey)
                ?.Value;

            if (claim is null)
            {
                claim = string.Empty;
            }

            return Guid.Parse(claim);
        }
    }
}