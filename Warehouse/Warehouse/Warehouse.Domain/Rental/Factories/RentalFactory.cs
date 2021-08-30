using System;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Domain.Rental.Factories
{
    internal static class RentalFactory
    {
        public static Entities.Rental Create(Guid userId)
            => new (Guid.NewGuid(), userId, RentalStatus.Started);
    }
}
