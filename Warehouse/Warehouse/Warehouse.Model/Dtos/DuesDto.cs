using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;
using Warehouse.Persistence.Entities.User.Entities;
using Warehouse.Persistence.Entities.User.Enums;

namespace Warehouse.Model.Dtos
{
	 public class DuesDto
	 {
		  protected DuesDto(
				    Guid id,
				    Guid userId,				    			    
				    int amount,
				    Status status,
				    Persistence.Entities.User.Enums.Half half)
		  {
			   Id = id;
			   UserId = userId;
			   Amount = amount;
			   Status = status;
			   Half = half;
		  }

		  public Guid Id { get; }
		  public Guid UserId { get; }
		  public int Amount { get; set; }
		  public Status Status { get; set; }
		  public Persistence.Entities.User.Enums.Half Half { get; set; }

		  public static explicit operator DuesDto(Dues dues)
			 =>new DuesDto(
				  dues.Id,
				  dues.UserId,
				  dues.Amount,
			       dues.Status,
				  dues.Half);
	 }
}
