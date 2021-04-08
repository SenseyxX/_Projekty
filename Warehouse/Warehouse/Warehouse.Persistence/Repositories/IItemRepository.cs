using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Repositories
{
        public interface IItemRepository
        {
                Task<IEnumerable<Item>> GetAllItemsAsync(CancellationToken cancellationToken);
                Task<Item> GetItemAsync(Guid Id);
                Task<Item> AddItemAsync(Item item);
                Task<Item> UpdateItemAsync(Item item);
                Task<Item> DelateItemAsync(Guid Id);
        }
}
