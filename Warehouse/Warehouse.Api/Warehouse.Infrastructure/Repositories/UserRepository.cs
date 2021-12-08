using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.User;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.Context;
using Warehouse.Infrastructure.Services;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }

        public override async Task<User> GetAsync(Guid squadId, CancellationToken cancellationToken)
            => await DbContext
                .Set<User>()
                .Include(user => user.Dues)
                .Include(user => user.OwnedItems)
                .Include(user => user.StoredItems)
                .FirstOrDefaultAsync(user => user.Id == squadId, cancellationToken);

        public override async Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken)
            => await GetWithDependencies()
                .ToListAsync(cancellationToken);

        private IQueryable<User> GetWithDependencies()
            => DbContext
                .Set<User>()
                .Include(user => user.Dues)
                .Include(user => user.OwnedItems)
                .Include(user => user.StoredItems);
    }
}
