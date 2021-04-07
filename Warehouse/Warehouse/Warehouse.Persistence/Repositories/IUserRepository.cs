using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
        public interface IUserRepository
        {
                Task<ICollection<User>> GetRangeAsync(CancellationToken cancellationToken);
                //Task<IEnumerable<User>> GetAllUsersAsync(); ??
                Task<User> GetUserAsync(Guid Id);
                Task<User> AddUserAsync(User user);
                Task UpdateUserAsync(User user);
                Task<User> DelateUserAsync(Guid Id);

        }
}
