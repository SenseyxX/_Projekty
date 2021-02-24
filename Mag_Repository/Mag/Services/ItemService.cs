using Mag.Dtos;
using Mag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
    public sealed class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemDto>> GetRangeAsync()
        {
            
            var items = await _itemRepository.GetAllAsync();          

            return items.Select(x => new ItemDto
            {
                Id = x.Id,
                ItemName = x.ItemName,
                QualityId = x.QualityId,
            });
        }
    }
}
