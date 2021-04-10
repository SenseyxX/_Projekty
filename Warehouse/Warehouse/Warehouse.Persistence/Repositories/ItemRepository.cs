using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    class ItemRepository : IItemRepository
    {
        private readonly WarehouseContext _warehouseContext;

        public ItemRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public async Task<Item> AddItemAsync(Item item)
        {
            await _warehouseContext.Items.AddAsync(item);
            await _warehouseContext.SaveChangesAsync();
            return null; //  czy null jest ok ? 
        }

        public async Task<Item> DeleteItemAsync(Guid Id)
        {
            var result = await _warehouseContext.Items
                    .FirstOrDefaultAsync(item => item.Id == Id);

            _warehouseContext.Items.Remove(result);
            await _warehouseContext.SaveChangesAsync();
            return null;
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(CancellationToken cancellationToken)
        {
            return await _warehouseContext.Items
                    .ToListAsync(cancellationToken);
        }

        public async Task<Item> GetItemAsync(Guid Id)
        {
            return await _warehouseContext.Items
                    .FirstOrDefaultAsync(item => item.Id == Id);
        }

        public Task<Item> UpdateItemAsync(Item item)
        {
            throw new NotImplementedException();
        }
    }
}
