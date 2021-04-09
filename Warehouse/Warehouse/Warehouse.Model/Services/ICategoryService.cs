using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>>GetCategoriesAsync(CancellationToken cancellationToken);
        Task<CategoryDto>GetCategoryAsync(Guid Id);
        Task<CategoryDto>AddCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category, Guid Id);
        Task DeleteCategoryAsync(Guid Id);
    }
}
