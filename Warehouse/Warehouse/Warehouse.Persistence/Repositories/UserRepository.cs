using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Persistence.Context;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
    public sealed class UserRepository : IUserRepository
    {
        private readonly WarehouseContext _warehouseContext;

        public UserRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public async Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken)
        {
            return await _warehouseContext.Users
                .ToListAsync(cancellationToken);
        }
    }
}
