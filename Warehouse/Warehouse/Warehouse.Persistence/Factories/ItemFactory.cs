using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;
using Warehouse.Persistence.Entities.Item.Entities;

namespace Warehouse.Persistence.Factories
{
    public static class ItemFactory
    {
        public static Item Create(
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            Guid? ownerId,
            Guid actualOwnerId)
            => new (
                Guid.NewGuid(),
                name,
                description,
                categoryId,
                qualityLevel,
                State.Active,
                ownerId,
                actualOwnerId);
    }
}
