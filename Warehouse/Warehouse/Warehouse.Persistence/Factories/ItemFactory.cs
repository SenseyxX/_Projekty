using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class ItemFactory // Factory tworzące nowe itemy
    {
        public static Item Create(
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            Guid? ownerId,
            Guid actualOwnerId)
            => new (
                Guid.NewGuid(),
                name,
                description,
                categoryId,
                qualityLevel,
                quantity,
                State.Active,
                ownerId,
                actualOwnerId);
    }
}
