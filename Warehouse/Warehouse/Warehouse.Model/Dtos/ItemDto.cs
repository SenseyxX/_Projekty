using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Model.Dtos
{
    public class ItemDto
    {
        protected ItemDto(Guid id,
            string name,
            string description,
            QualityLevel qualityLevel,
            int quantity,
            State state,
            Guid? ownerId,
            Guid actualOwnerId)
        {
            Id = id;
            Name = name;
            Description = description;
            QualityLevel = qualityLevel;
            Quantity = quantity;
            State = state;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
            
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public QualityLevel QualityLevel { get; }
        public int Quantity { get; }
        public State State { get; }
        public Guid? OwnerId { get; }
        public Guid ActualOwnerId { get;}


        public static explicit operator ItemDto(Item item)
                => new (
                    item.Id,
                    item.Name,
                    item.Description,
                    item.QualityLevel,
                    item.Quantity,
                    item.State,
                    item.OwnerId,
                    item.ActualOwnerId);
    }
}
