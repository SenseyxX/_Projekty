using System;

namespace Warehouse.Application.Contracts.Commands.Squad
{
	 public sealed class UpdateTeamCommand
	 {	  
		  public string Name { get; set; }
		  public Guid TeamOwnerId { get; set; }
		  public string Description { get; set; }
		  public int Points { get; set; }		  
	 }
}
