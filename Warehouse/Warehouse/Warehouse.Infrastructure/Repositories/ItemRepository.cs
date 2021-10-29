using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Item;
using Warehouse.Domain.Item.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class ItemRepository : Repository<Item>, IItemRepository // Repozytorium do połączenia z bazą oraz metody do edycji danych na bazie
    {
        public ItemRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }

        // Dodanie nowej metody która nie jest dziedzioczona z clasy Repository

        // Add to GetWithDependencies
        public override async Task<Item> GetAsync(Guid id, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .FirstOrDefaultAsync(item => item.Id == id, cancellationToken);

        public async Task<Item> GetByCodeAsync(string itemCode, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .FirstOrDefaultAsync(item => item.Name == itemCode, cancellationToken);
    }
}
