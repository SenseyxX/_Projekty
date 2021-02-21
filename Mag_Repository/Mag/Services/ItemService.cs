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
            var items = await _itemRepository.GetRangeAsync();

            //var result = new List<ItemDto>();

            //foreach (var item in items)
            //{
            //    var newItem = new ItemDto
            //    {
            //        Id = item.Id,
            //        ItemName = item.ItemName,
            //    };

            //    result.Add(newItem);
            //}

            //return result;

            return items.Select(x => new ItemDto
            {
                Id = x.Id,
                ItemName = x.ItemName,
            });
        }
    }
}
