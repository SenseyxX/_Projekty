using System;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.User.Enumeration;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Domain.User.Entities
{
	 public sealed class Due : Entity
	 {
         public Due(
             Guid id,
             Guid userId,
             Half half,
             int amount,
             DueStatus dueStatus)
             : base(id)
		  {
			   UserId = userId;
			   Half = half;
			   Amount = amount;
			   DueStatus = dueStatus;
		  }

		  public Guid UserId { get; }
		  public Half Half { get; }
		  public int Amount { get; private set; }
		  public DueStatus DueStatus { get; private set; }

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
			   if (DueStatus == DueStatus.Paid)
			   {
				    return false;
			   }

			   DueStatus = DueStatus.Paid;
			   return true;
		  }

          public bool Waiting()
		  {
			   if (DueStatus == DueStatus.Waiting)
			   {
				    return false;
			   }

			   DueStatus = DueStatus.Waiting;
			   return true;
		  }
	 }
}
