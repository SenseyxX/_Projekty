using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;

namespace Warehouse.Persistence.Factories
{
    public static class CategoryFactory
    {
        public static Category Create(string name, string description )
            => new (
                Guid.NewGuid(),
                name,
                description,
                State.Active);
    }
}
