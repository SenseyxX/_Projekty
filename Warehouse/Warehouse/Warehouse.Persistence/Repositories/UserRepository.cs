using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.User.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }
    }
}
