using AutoMapper;
using Mag.Dtos;
using Mag.Dtos.ItemDtos;
using Mag.Entities;
using Mag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<ItemGetDto> AddUserAsync(ItemAddDto itemAddDto)
        {
            var item = _mapper.Map<Item>(itemAddDto);
            var createdItem = await _itemRepository.AddItemAsync(item);
            throw new NotImplementedException();
        }

        public Task DelateUserAsync(int itemid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemGetDto>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ItemGetDto> GetUserAsync(int itemid)
        {
            throw new NotImplementedException();
        }

        public Task<ItemGetDto> UpdateUserAsync(int id, ItemUpdateDto item)
        {
            throw new NotImplementedException();
        }
    }
}
