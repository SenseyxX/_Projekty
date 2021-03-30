using Mag.Dtos;
using Mag.Dtos.ItemDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mag.Services
{
        public interface IItemService
        {
        Task<IEnumerable<ItemGetDto>> GetAllUsersAsync();
        Task<ItemGetDto> GetUserAsync(int itemid);
        Task<ItemGetDto> AddUserAsync(ItemAddDto itemAddDto);
        Task<ItemGetDto> UpdateUserAsync(int id, ItemUpdateDto itemUpdateDto);
        Task DelateUserAsync(int itemid);
    }
}
