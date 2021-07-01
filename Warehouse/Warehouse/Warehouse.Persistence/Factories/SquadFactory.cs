using System;
using Warehouse.Persistence.Entities;

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
