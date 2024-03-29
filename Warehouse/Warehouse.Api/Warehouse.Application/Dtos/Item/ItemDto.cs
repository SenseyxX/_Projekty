﻿using System;
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
            State state,
            Guid? ownerId,
            Guid actualOwnerId)
        {
            Id = id;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            QualityLevel = qualityLevel;
            Quantity = quantity;
            State = state;
            OwnerId = ownerId;
            ActualOwnerId = actualOwnerId;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
	    public Guid CategoryId { get;}
        public  string CategoryName { get; set; }
	    public QualityLevel QualityLevel { get; }
        public string QualityLevelName { get; set; }
        public int Quantity { get; }
        public State State { get; }
        public Guid? OwnerId { get; }
        public string OwnerName { get; set; }
        public Guid ActualOwnerId { get;}
        public string ActualOwnerName { get; set; }

        public static explicit operator ItemDto(Domain.Item.Entities.Item item)
                => new (
                    item.Id,
                    item.Name,
                    item.Description,
                    item.CategoryId,
                    item.QualityLevel,
                    item.Quantity,
                    item.State,
                    item.OwnerId,
                    item.ActualOwnerId);
    }
}
