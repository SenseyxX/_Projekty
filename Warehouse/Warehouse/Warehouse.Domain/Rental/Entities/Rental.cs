using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Rental.Enumeration;

namespace Warehouse.Domain.Rental.Entities
{
	 public sealed class Rental : Aggregate
	 {
         internal Rental(
              Guid id,
              Guid userId,
              RentalStatus rentalStatus)
              : base(id)
		  {
			   UserId = userId;
			   RentalStatus = rentalStatus;
			   RentalItems = new List<RentalItem>();
		  }

		  public Guid UserId { get; }
		  public RentalStatus RentalStatus { get; private set; }
		  ICollection<RentalItem> RentalItems { get; }
     }
}

