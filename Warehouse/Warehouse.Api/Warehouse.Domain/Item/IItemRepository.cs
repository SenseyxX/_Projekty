using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Domain.Abstractions;

namespace Warehouse.Domain.Item
{
    public interface IItemRepository : IRepository<Entities.Item>
    {
        Task<Entities.Item> GetByCodeAsync(string itemCode, CancellationToken cancellationToken);
    }
}
