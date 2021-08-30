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
		  public Guid UserId { get; init; }
		  public Half Half { get; init; }
		  public int Amount { get; init; }
		  public Status Status { get; init; }
	 }
}
