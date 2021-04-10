using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(WarehouseContext warehouseContext)
         : base(warehouseContext)
        {
        }

        public override async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<Category>()
                .Include(category => category.Items)
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }
}
