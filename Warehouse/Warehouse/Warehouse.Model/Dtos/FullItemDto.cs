using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullItemDto : ItemDto
    {
        private FullItemDto(
            Guid id,
            string name,
            string description)
        { }

        public static explicit operator FullItemDto(Item item)
            => new(item.Id,
            item.Name,
            item.Description);
    }
}
