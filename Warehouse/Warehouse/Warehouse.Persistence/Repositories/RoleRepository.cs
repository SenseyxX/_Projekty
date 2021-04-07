using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities.Role;

namespace Warehouse.Persistence.Repositories
{
        class RoleRepository : IRoleRepository
        {
                private readonly WarehouseContext _warehouseContext;

                public RoleRepository(WarehouseContext warehouseContext)
                {
                        _warehouseContext = warehouseContext;
                }

                public async Task<Role> GetRoelAsync(Guid Id)
                {                       
                        return  await _warehouseContext.Roles
                                .FirstOrDefaultAsync(role => role.Id == Id);
                }
        }
}
