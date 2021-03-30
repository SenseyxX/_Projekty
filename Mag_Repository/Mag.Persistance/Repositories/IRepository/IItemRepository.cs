using Mag.Entities;
using System.Collections.Generic;
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
