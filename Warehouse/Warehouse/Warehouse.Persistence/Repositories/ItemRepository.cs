using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class ItemRepository : Repository<Item>, IItemRepository // Repozytorium do połączenia z bazą oraz metody do edycji danych na bazie
    {
        public ItemRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }
            
        // Dodanie nowej metody która nie jest dziedzioczona z clasy Repository
        public override async Task<Item> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);
    }
}
