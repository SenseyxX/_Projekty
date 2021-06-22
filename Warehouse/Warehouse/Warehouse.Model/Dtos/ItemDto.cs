using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Model.Dtos
{
    public class ItemDto
    {
        protected ItemDto(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }

        //ToDo
        //public Guid CategoryId { get; set; }
        //public Guid QualityId { get; set; }
        //public Quality Quality { get; set; }
        //public ICollection<LoanHistory> LoanHistories { get; set; }
        //public Guid? OwnerId { get; set; }
        //public Guid ActualOwnerId { get; set; }

        public static explicit operator ItemDto(Item item)
                => new ItemDto(item.Id, item.Name, item.Description);
    }
}
