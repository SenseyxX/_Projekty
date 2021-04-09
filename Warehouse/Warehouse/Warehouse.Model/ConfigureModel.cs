using Microsoft.Extensions.DependencyInjection;
using Warehouse.Model.Services;

namespace Warehouse.Model
{
    public static class ConfigureModel
    {
        public static IServiceCollection RegisterModelDependencies(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddTransient<ICategoryService, CategoryService>()
                .AddTransient<IItemService,ItemService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IQualityService, QualityService>()
                .AddTransient<ILoanHistoryService,LoanHistoryService>()
                .AddTransient<IRoleService, RoleService>()
                .AddTransient<ISquadService, SquadService>();
        }
    }
}
