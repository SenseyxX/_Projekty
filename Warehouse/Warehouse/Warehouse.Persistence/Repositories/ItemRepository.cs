using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }

        public override async Task<Item> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }
}
