using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Model.Contracts.Commands
{
	 public sealed class CreateTeamCommand
	 {
		  public string Name { get; init; }
		  public Guid TeamOwnerId { get; init; }
		  public string Description { get; init; }
		  public int Points { get; init; }
	 }
}
