using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.User.Enums;
using Half = Warehouse.Persistence.Entities.User.Enums.Half;

namespace Warehouse.Model.Contracts.Commands
{
	 public sealed class CreateDuesCommand
	 {
		  public Guid UserId { get; set; }
		  public Half Half { get; set; }
		  public int Amount { get; set; }
		  public Status Status { get; set; }
	 }
}
