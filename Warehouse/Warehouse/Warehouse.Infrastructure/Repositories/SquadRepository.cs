using Warehouse.Domain.Squad;
using Warehouse.Domain.Squad.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class SquadRepository : Repository<Squad>, ISquadRepository
    {
        public SquadRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }
    }
}
