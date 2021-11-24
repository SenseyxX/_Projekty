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
            string name,
            Guid userId,
            RentalStatus rentalStatus,
            IEnumerable<RentalItemDto> rentalItemDto)    
                : base (id,
                        name,
                        userId,
                        rentalStatus)
        {
            RentalItemDto = rentalItemDto;
        }

        public IEnumerable<RentalItemDto> RentalItemDto { get;  }

        public static explicit operator FullRentalDto(Domain.Rental.Entities.Rental rental)
            => new(
                rental.Id,
                rental.Name,
                rental.UserId,
                rental.RentalStatus,
                rental.RentalItems.Select(rentalItem => (Rental.RentalItemDto)rentalItem));
    }   
}