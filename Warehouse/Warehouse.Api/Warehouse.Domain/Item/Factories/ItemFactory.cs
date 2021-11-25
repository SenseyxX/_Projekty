using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Item.Enumeration;

namespace Warehouse.Domain.Item.Factories
{
    public static class ItemFactory // Factory tworzące nowe itemy
    {
        public static Entities.Item Create(
            string name,
            string description,
            Guid categoryId,
            QualityLevel qualityLevel,
            int quantity,
            Guid ownerId)
            => new (
                Guid.NewGuid(),
                name,
                description,
                categoryId,
                qualityLevel,
                quantity,
                State.Active,
                ownerId,
                ownerId);
    }
}
