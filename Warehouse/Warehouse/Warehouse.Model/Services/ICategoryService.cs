using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Contracts.Commands;
using Warehouse.Model.Dtos;

namespace Warehouse.Model.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetCategoriesAsync(CancellationToken cancellationToken);
        Task<FullCategoryDto> GetCategoryAsync(Guid id, CancellationToken cancellationToken);
        Task AddCategoryAsync(AddCategoryCommand addCategoryCommand, CancellationToken cancellationToken);
        Task UpdateCategoryAsync(UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken);
        Task DeleteCategoryAsync(Guid Id);
    }
}
