using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Item.Entities;
using Warehouse.Domain.User;
using Warehouse.Domain.User.Entities;
using Warehouse.Infrastructure.Persistence.Context;

namespace Warehouse.Infrastructure.Repositories
{
    public sealed class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(WarehouseContext warehouseContext)
            : base(warehouseContext)
        {
        }

        public override async Task<User> GetAsync(Guid id, CancellationToken cancellationToken)
            => await GetWithDependencies()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);

        public override async Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken)
            => await GetWithDependencies()
                .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Item>> GetUserItemsAsync(
            Guid userId,
            CancellationToken cancellationToken)
            => await DbContext
                .Set<Item>()
                .AsNoTracking()
                .Include(item => item.OwnerId)
                .Include(item => item.ActualOwnerId)
                .Where(user => user.Id == userId)
                .ToListAsync(cancellationToken);

        public async Task<bool> IsEmailRegisteredAsync(string emailAddress, CancellationToken cancellationToken) =>
            await DbContext.Set<User>()
                .AnyAsync(user => user.Email == emailAddress, cancellationToken);

        public async Task<ICollection<User>> GetUsersAsync(IEnumerable<string> userEmails, CancellationToken cancellationToken) =>
            await DbContext.Set<User>()
            .AsNoTracking()
            .Where(user => userEmails.Any(email => user.Email == email))
            .ToListAsync(cancellationToken);

        private IQueryable<User> GetWithDependencies()
            => DbContext
                .Set<User>()
                .AsNoTrackingWithIdentityResolution()
                .Include(user => user.Dues)
                .Include(user => user.OwnedItems)
                .Include(user => user.StoredItems);

    }
}
