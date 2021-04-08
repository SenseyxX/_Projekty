using System;
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

                public async Task<User> AddUserAsync(User user)
                {
                        var result = await _warehouseContext.Users.AddAsync(user);
                        await _warehouseContext.SaveChangesAsync();
                        return null; // ? czy null jest ok ? 
                }

                public async Task<User> DelateUserAsync(Guid Id)
                {
                        var result = await _warehouseContext.Users
                                .FirstOrDefaultAsync(user => user.Id == Id);

                        _warehouseContext.Users.Remove(result);
                        await _warehouseContext.SaveChangesAsync();
                        return null;
                }

                public async Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken)
                {
                        return await _warehouseContext.Users
                            .ToListAsync(cancellationToken);
                }

                public async Task<User> GetUserAsync(Guid Id)
                {
                        return await _warehouseContext.Users
                                .FirstOrDefaultAsync(user => user.Id == Id);
                }

                public Task UpdateUserAsync(User user)
                {
                        throw new System.NotImplementedException();
                }
        }
}
