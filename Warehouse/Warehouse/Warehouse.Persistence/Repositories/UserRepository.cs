using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
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
		  public async override Task<User> GetAsync(Guid id, CancellationToken cancellationToken)
		  {
			   return await DbContext
				    .Set<User>()
				    .Include(user => user.Dues)
				    .Include(user => user.OwnedItems)
				    .Include(user => user.StoredItems)
				    .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
		  }
		  public async override Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken)
		  {
			   return await DbContext
				    .Set<User>()
				    .Include(user => user.Dues)
				    .Include(user => user.OwnedItems)
				    .Include(user => user.StoredItems)
				    .ToListAsync(cancellationToken);
		  }
	 }
}
