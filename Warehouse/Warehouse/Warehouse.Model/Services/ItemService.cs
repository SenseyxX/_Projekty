using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.Model.Dtos;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Repositories;

namespace Warehouse.Model.Services
{
    public sealed class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<ItemDto> AddItemAsync(Item item)
        {
            var result = await _itemRepository.AddItemAsync(item);
            return (ItemDto)result;
        }

        public async Task DeleteItemAsync(Guid Id)
        {
            // await _itemRepository.DelateItemAsync(Id);
        }

        public async Task<ItemDto> GetItemAsync(Guid Id)
        {
            var result = await _itemRepository.GetItemAsync(Id);
            return (ItemDto)result;
        }

        public async Task<IEnumerable<ItemDto>> GetItemsAsync(CancellationToken cancellationToken)
        {
            var result = await _itemRepository.GetItemsAsync(cancellationToken);
            return result.Select(item => (ItemDto)item);
        }

        public  Task UpdateItemAsync(User user, Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
