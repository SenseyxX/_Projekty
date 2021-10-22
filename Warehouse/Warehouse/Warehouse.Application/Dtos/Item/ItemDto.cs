using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Application.Dtos.Item
{
    public class ItemDto
    {
        protected ItemDto(
            Guid id,
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            CategoryState categoryState,
            Guid? ownerId,
            Guid actualOwnerId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            QualityLevel = qualityLevel;
            Quantity = quantity;
            CategoryState = categoryState;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
	    public Guid CategoryId { get;}
	    public QualityLevel QualityLevel { get; }
        public int Quantity { get; }
        public CategoryState CategoryState { get; }
        public Guid? OwnerId { get; }
        public Guid ActualOwnerId { get;}

        public static explicit operator ItemDto(Domain.Item.Entities.Item item)
                => new (
                    item.Id,
                    item.Name,
                    item.Description,
                    item.CategoryId,
                    item.QualityLevel,
                    item.Quantity,
                    item.CategoryState,
                    item.OwnerId,
                    item.ActualOwnerId);
    }
}
