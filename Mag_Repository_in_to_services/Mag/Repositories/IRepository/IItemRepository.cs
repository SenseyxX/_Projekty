using Mag.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
    public interface IItemRepository 
    {
                Task<IEnumerable<Item>> GetAllItemsAsync();
                Task<Item> GetItemAsync(int itemId);
                Task<Item> AddItemAsync(Item item);
                Task<Item> UpdateItemAsync(Item item);
                Task<Item> DelateItemAsync(int itemId);
    }
}
