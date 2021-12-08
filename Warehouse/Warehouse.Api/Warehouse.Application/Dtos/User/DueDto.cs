using System;
using Warehouse.Domain.User.Entities;
using Warehouse.Domain.User.Enumeration;
using Half = Warehouse.Domain.User.Enumeration.Half;

namespace Warehouse.Application.Dtos.User
{
	 public class DueDto
	 {
		  protected DueDto(
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
		  public int Amount { get; }
          public DueStatus DueStatus { get; }
          public Half Half { get; }

		  public static explicit operator DueDto(Due dues)
			 => new (
				  dues.Id,
				  dues.UserId,
				  dues.Amount,
			      dues.DueStatus,
				  dues.Half);
	 }
}
