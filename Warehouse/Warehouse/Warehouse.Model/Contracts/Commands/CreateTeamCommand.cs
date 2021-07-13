using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
	 public sealed class CreateTeamCommand
	 {
		  public string Name { get; set; }
		  public Guid TeamOwnerId { get; set; }
		  public string Description { get; set; }
		  public int Points { get; set; }
	 }
}
