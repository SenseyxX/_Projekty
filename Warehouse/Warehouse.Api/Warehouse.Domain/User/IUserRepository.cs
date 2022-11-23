using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Abstractions;

namespace Warehouse.Domain.User
{
    public interface IUserRepository : IRepository<Entities.User>
    {       
        Task<IEnumerable<Item.Entities.Item>> GetUserItemsAsync(Guid userId, CancellationToken cancellationToken);

        Task<bool> IsEmailRegisteredAsync(string emailAddress, CancellationToken cancellationToken);
    }
}
