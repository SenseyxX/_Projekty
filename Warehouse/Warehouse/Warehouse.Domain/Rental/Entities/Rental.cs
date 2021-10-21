using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Rental.Enumeration;
using Warehouse.Domain.Rental.Factories;

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

          public void PickItem(string rentalItemCode)
          {
              if (RentalStatus == RentalStatus.Started)
              {
                 RentalStatus = RentalStatus.Picking;
              }

              if (RentalStatus != RentalStatus.Picking)
              {
                  throw new Exception();
              }

              // var isUnique = true;
              // foreach (var rentalItem in RentalItems)
              // {
              //     if (rentalItem.RentalItemCode == rentalItemCode)
              //     {
              //         isUnique = false;
              //     }
              // }

              // isUnique = !RentalItems.Any(rentalItem => rentalItem.RentalItemCode == rentalItemCode);

              // if (!isUnique)
              // {
              //     throw new Exception();
              // }

              if (RentalItems.Any(rentalItem => rentalItem.RentalItemCode == rentalItemCode))
              {
                  throw new Exception();
              }

              // ToDo: Add item status validation
              var rentalItem = RentalItemFactory.Create(rentalItemCode);
              RentalItems.Add(rentalItem);
          }

          public void FinishPicking()
          {
              if (RentalStatus != RentalStatus.Picking)
              {
                  throw new Exception();
              }

              RentalStatus = RentalStatus.Returning;
          }

          public void ReturnItem(string rentalItemCode)
          {
              if (RentalStatus != RentalStatus.Returning)
              {
                  throw new Exception();
              }

              if (RentalItems.All(returnItem => returnItem.RentalItemCode != rentalItemCode))
              {
                  throw new Exception();
              }

              RentalItems
                  .First(rentalItem => rentalItem.RentalItemCode == rentalItemCode)
                  .Return();
          }

          public void FinishReturning()
          {
              if (RentalStatus != RentalStatus.Returning)
              {
                  throw new Exception();
              }

              RentalStatus = RentalStatus.Finished;
          }
     }
}

