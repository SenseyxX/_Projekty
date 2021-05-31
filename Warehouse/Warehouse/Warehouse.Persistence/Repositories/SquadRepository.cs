using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    class SquadRepository : Repository<Squad>, ISquadRepository
    {
        public SquadRepository(WarehouseContext warehouseContext)
         :base(warehouseContext)
        {
        }       
    }
}
