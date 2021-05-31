using System;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.Item;

namespace Warehouse.Persistence.Factories
{
    public static class SquadFactory
    {
        public static Squad Create(string name)
            => new(
            Guid.NewGuid(),
            name,
            State.Active);
    }
}
