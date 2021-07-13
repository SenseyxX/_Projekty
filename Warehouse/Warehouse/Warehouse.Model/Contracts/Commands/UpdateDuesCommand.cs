using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities.User.Enums;

namespace Warehouse.Model.Contracts.Commands
{
	 public sealed class UpdateDuesCommand
	 {
		  public int Amount { get; set; }		  
		  Status Status { get; set; }
	 }
}
