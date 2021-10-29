using System;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Application.Dtos.Rental
{
    public class RentalDto
    {
        protected RentalDto(
            Guid id,
            Guid userId,
            RentalStatus rentalStatus)
        {
            Id = id;
            UserId = userId;
            RentalStatus = rentalStatus;
        }

        public Guid Id { get; }
        public Guid UserId { get;}
        public RentalStatus RentalStatus { get; }

        public static explicit operator RentalDto(Domain.Rental.Entities.Rental rental)
            => new(
                rental.Id,
                rental.UserId,
                rental.RentalStatus);
    }
}