using Mag.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Repositories
{
        public sealed class ItemRepository : IItemRepository
        {
                private readonly MagContext _magContext;

                public ItemRepository(MagContext magContext)
                {
                    this._magContext = magContext;
                }

                public async Task<Item> AddItemAsync(Item item)
                {
                        var result = await _magContext.Items.AddAsync(item);
                        await _magContext.SaveChangesAsync();
                        return result.Entity;
                }
                               

                public async Task<IEnumerable<Item>> GetAllItemsAsync()
                {
                        var result = await _magContext.Items.ToListAsync();
                        return (result);
                }

                public async Task<Item> GetItemAsync(int itemId)
                {
                        var result = await _magContext.Items
                                .FirstOrDefaultAsync(m => m.Id == itemId);
                        return result;
                }

                public async Task<Item> UpdateItemAsync(Item item)
                {
                        var result = await _magContext.Items
                                .FirstOrDefaultAsync(m => m.Id == item.Id);
                        if (result!=null)
                        {
                                result.ItemName = item.ItemName;
                                result.QualityId = item.QualityId;
                                result.Quantity = item.Quantity;
                                result.OwnerId = item.OwnerId;                                
                                result.Description = item.Description;                                                           

                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }

                public  async Task<Item>DelateItemAsync(int itemId)
                {
                        var result = await _magContext.Items.FirstOrDefaultAsync(m => m.Id == itemId);
                        if (result != null)
                        {
                                _magContext.Items.Remove(result);
                                await _magContext.SaveChangesAsync();
                                return result;
                        }
                        return null;
                }
        }
}
