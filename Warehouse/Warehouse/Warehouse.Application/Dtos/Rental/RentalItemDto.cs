using System;
using Warehouse.Domain.Rental.Entities;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Application.Dtos.Rental
{
    public sealed class RentalItemDto
    {
        private RentalItemDto(
            Guid id,
            string rentalItemCode,
            RentalItemStatus rentalItemStatus)
        {
            Id = id;
            RentalItemCode = rentalItemCode;
            RentalItemStatus = rentalItemStatus;
        }

        public Guid Id { get; }
        public string RentalItemCode { get; }
        public RentalItemStatus RentalItemStatus { get; }

        public static explicit operator RentalItemDto(RentalItem rentalItem)
            => new(
                rentalItem.Id,
                rentalItem.RentalItemCode,
                rentalItem.RentalItemStatus);
    }
}