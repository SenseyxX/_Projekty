using System;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Category.Factories
{
    public static class CategoryFactory
    {
        public static Entities.Category Create(
            string name,
            string description )
            => new (
                Guid.NewGuid(),
                name,
                description,
                CategoryState.Active);
    }
}
