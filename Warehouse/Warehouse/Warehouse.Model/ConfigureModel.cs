using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Warehouse.Model.DomainServices;
using Warehouse.Model.Helpers;
using Warehouse.Model.Services;

namespace Warehouse.Model
{
    public static class ConfigureModel
    {
        private const string EncryptionSectionKey = "EncryptionSettings";
        private const string TokenSectionKey = "TokenSettings";

        public static IServiceCollection RegisterModelDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
        {
            return serviceCollection.Configure<EncryptionSettings>(configuration.GetSection(EncryptionSectionKey))
                .Configure<TokenSettings>(configuration.GetSection(TokenSectionKey))
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IItemService, ItemService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<ISquadService, SquadService>()
                .AddTransient<IAuthenticationService, AuthenticationService>()
                .AddTransient<ItemDomainService>()
                .AddTransient<EncryptionService>()
                .AddTransient<TokenService>();
        }
    }
}
