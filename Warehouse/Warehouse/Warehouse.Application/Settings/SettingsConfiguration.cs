using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Warehouse.Application.Settings
{
    internal static class SettingsConfiguration
    {
        private const string EncryptionSectionKey = "EncryptionSettings";
        private const string TokenSectionKey = "TokenSettings";

        public static IServiceCollection RegisterSettingsDependencies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration)
            => serviceCollection
                .Configure<EncryptionSettings>(configuration.GetSection(EncryptionSectionKey))
                .Configure<TokenSettings>(configuration.GetSection(TokenSectionKey));
    }
}
