using System;
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
            => await DbContext
                .Set<Rental>()
                .Include(rentalItem => rentalItem.RentalItems)
                .FirstOrDefaultAsync(rentalItem => rentalItem.Id == id, cancellationToken);
    }
}
