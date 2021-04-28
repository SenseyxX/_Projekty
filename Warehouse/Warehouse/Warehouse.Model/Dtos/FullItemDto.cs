using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Model.Dtos
{
    public sealed class FullItemDto : ItemDto
    {
        private FullItemDto(
            Guid id,
            string name,
            string description)
            : base(id, name, description)
        {
        }

        // ToDo: Verify if needed.
        public static explicit operator FullItemDto(Item item)
            => new(item.Id, item.Name, item.Description);
    }
}
