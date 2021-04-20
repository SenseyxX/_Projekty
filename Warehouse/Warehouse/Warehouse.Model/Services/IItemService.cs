using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken);
        Task<ItemDto> GetItemAsync(Guid Id, CancellationToken cancellationToken);
        Task AddItemAsync(Item item, CancellationToken cancellationToken);
        Task UpdateItemAsync(User user, CancellationToken cancellationToken);
        Task DeleteItemAsync(Guid Id);
    }
}
