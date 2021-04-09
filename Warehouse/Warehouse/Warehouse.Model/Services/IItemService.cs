using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Services
{
    public interface IItemService
    {
        Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken);
        Task<ItemDto> GetItemAsync(Guid Id);
        Task<ItemDto> AddItemAsync(Item item);
        Task UpdateItemAsync(User user, Guid Id);
        Task DeleteItemAsync(Guid Id);
    }
}
