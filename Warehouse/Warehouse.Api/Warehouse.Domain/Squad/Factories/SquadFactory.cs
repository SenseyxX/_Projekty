using System;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Squad.Factories
{
    public static class SquadFactory
    {
        public static Entities.Squad Create(Guid squadOwnerId, string name)
            => new(
            Guid.NewGuid(),
            name,
            squadOwnerId,
            State.Active);
    }
}
