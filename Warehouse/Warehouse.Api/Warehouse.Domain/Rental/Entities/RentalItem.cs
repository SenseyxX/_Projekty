using System;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Domain.Rental.Entities
{
	 public sealed class RentalItem : Entity
	 {
         internal RentalItem(
			   Guid id,
			   string rentalItemCode,
			   RentalItemStatus rentalItemStatus)
			   : base(id)
		  {
			   RentalItemCode = rentalItemCode;
			   RentalItemStatus = rentalItemStatus;
		  }

		  public string RentalItemCode { get; }
		  public RentalItemStatus RentalItemStatus { get; private set; }

          internal void Return()
          {
              if (RentalItemStatus != RentalItemStatus.Picked)
              {
                  throw new Exception();
              }

              RentalItemStatus = RentalItemStatus.Returned;
          }
     }
}
