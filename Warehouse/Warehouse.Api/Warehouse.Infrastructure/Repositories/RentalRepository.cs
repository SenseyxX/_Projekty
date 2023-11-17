using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Rental;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class RentalRepository : Repository<Rental>, IRentalRepository
    {
        public RentalRepository(WarehouseContext dbContext)
            : base(dbContext)
        {
        }

        public override async Task<Rental> GetAsync(Guid id, CancellationToken cancellationToken)
            => await GetWithDependencies()
                .FirstOrDefaultAsync(rentalItem => rentalItem.Id == id, cancellationToken);

        public override async Task<ICollection<Rental>> GetRangeAsync(CancellationToken cancellationToken)
            => await GetWithDependencies()
                .ToListAsync(cancellationToken);

        private IQueryable<Rental> GetWithDependencies()
            => DbContext
                .Set<Rental>()
                .AsNoTracking()
                .Include(rentalItems => rentalItems.RentalItems);
    }
}
