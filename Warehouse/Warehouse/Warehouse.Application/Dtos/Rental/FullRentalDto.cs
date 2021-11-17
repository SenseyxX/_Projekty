using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Application.Dtos.Rental
{
    public sealed class FullRentalDto : RentalDto
    {
        private FullRentalDto(
            Guid id,
            Guid userId,
            RentalStatus rentalStatus,
            IEnumerable<RentalItemDto> rentalItemDto)    
                : base (id,
                        userId,
                        rentalStatus)
        {
            RentalItemDto = rentalItemDto;
        }

        public IEnumerable<RentalItemDto> RentalItemDto { get;  }

        public static explicit operator FullRentalDto(Domain.Rental.Entities.Rental rental)
            => new(
                rental.Id,
                rental.UserId,
                rental.RentalStatus,
                rental.RentalItems.Select(rentalItem => (Rental.RentalItemDto)rentalItem));
    }   
}