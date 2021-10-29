using System;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Domain.Rental.Factories
{
    internal static class RentalItemFactory
    {
        public static RentalItem Create(string rentalItemCode)
            => new(Guid.NewGuid(), rentalItemCode, RentalItemStatus.Picked);
    }
}
