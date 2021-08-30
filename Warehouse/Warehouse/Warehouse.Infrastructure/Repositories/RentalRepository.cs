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
    }
}
