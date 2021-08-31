using System;
using Warehouse.Domain.User.Entities;
using Warehouse.Domain.User.Enumeration;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Application.Dtos
{
	 public class DuesDto
	 {
		  protected DuesDto(
				    Guid id,
				    Guid userId,				    			    
				    int amount,
				    DueStatus dueStatus,
				    Half half)
		  {
			   Id = id;
			   UserId = userId;
			   Amount = amount;
			   DueStatus = dueStatus;
			   Half = half;
		  }

		  public Guid Id { get; }
		  public Guid UserId { get; }
		  public int Amount { get; set; }
		  public DueStatus DueStatus { get; set; }
		  public Half Half { get; set; }

		  public static explicit operator DuesDto(Due dues)
			 =>new DuesDto(
				  dues.Id,
				  dues.UserId,
				  dues.Amount,
			       dues.DueStatus,
				  dues.Half);
	 }
}
