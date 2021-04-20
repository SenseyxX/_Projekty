using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Repositories
{
    class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(WarehouseContext warehouseContext)
         :base(warehouseContext)
        {
        }        
    }
}
