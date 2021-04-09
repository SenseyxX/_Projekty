using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class CategoryRepository : ICategoryRepository
    {
        private readonly WarehouseContext _warehouseContext;

        public CategoryRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            await _warehouseContext.Categories.AddAsync(category);
            await _warehouseContext.SaveChangesAsync();
            return null; // ? czy null jest ok ? 
        }

        public async Task<Category> DeleteCategoryAsync(Guid Id)
        {
            var result = await _warehouseContext.Categories
                    .FirstOrDefaultAsync(category => category.Id == Id);

            _warehouseContext.Categories.Remove(result);
            await _warehouseContext.SaveChangesAsync();
            return null;

        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken)
        {
            return await _warehouseContext.Categories
                    .ToListAsync(cancellationToken);
        }

        public async Task<Category> GetCategoryAsync(Guid Id)
        {
            return await _warehouseContext.Categories
                    .FirstOrDefaultAsync(category => category.Id == Id);
        }
        //ToDo
        public Task<Category> UpdateCategoryAsync(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
