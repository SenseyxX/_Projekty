using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Category;
using Warehouse.Domain.Category.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }

        // Jeśli była by potrzeba zmienić coś w zględem base repo
        public override async Task<Category> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<Category>()
                .Include(category => category.Items)
                .FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
    }
}
