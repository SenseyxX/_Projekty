using System;
using System.Collections.Generic;
using System.Linq;
using Warehouse.Persistence.Entities.Abstractions;
using Warehouse.Persistence.Entities.User.Enums;
using Half = Warehouse.Persistence.Entities.User.Enums.Half;

namespace Warehouse.Persistence.Entities
{
	 public sealed class Due : Entity
	 {
		  public Due(
			   Guid id,
			   Guid userId,
			   Half half,
			   int amount,
			   Status status
			   ):base(id)
		  {
			   UserId = userId;
			   Half = half;
			   Amount = amount;
			   Status = status;
		  }

		  public Guid UserId { get; }
		  public Half Half { get; }
		  public int Amount { get; private set; }
		  public Status Status { get; private set; }

		  public bool UpdateAmount(int amount)
		  {
			   if (Amount == amount)
			   {
				    return false;
			   }

			   Amount = amount;
			   return true;
		  }

		  public bool Paid()
		  {
			   if (Status == Status.Paid)
			   {
				    return false;
			   }

			   Status = Status.Paid;
			   return true;		  
		  }


		  public bool Waiting()
		  {
			   if (Status == Status.Waiting)
			   {
				    return false;
			   }

			   Status = Status.Waiting;
			   return true;
		  }
	 }
}
