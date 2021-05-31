using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WarehouseContext warehouseContext)
         :base(warehouseContext)
        {
        }       
    }
}
