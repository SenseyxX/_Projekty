using System;
using System.Collections.Generic;
using System.Linq;
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

        // ToDo: Add to GetWithDependencies
        public override async Task<Item> GetAsync(Guid squadId, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .AsNoTrackingWithIdentityResolution()
                .FirstOrDefaultAsync(item => item.Id == squadId, cancellationToken);

        public async Task<Item> GetByCodeAsync(string itemCode, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .AsNoTrackingWithIdentityResolution()
                .Include(item => item.LoanHistories)
                .FirstOrDefaultAsync(item => item.Name == itemCode, cancellationToken);

        public async Task<ICollection<Item>> GetByUserIdAsync(Guid userId, CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .Include(item => item.LoanHistories)
                .AsNoTrackingWithIdentityResolution()
                .Where(item => item.OwnerId == userId)
                .ToListAsync(cancellationToken);
        
    }
}
