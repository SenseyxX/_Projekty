using System;

namespace Warehouse.Application.Contracts.Commands.Squad
{
	 public sealed class UpdateTeamCommand
	 {
		 public Guid TeamId { get; set; }
		 public string Name { get; set; }
		 public Guid squadId { get; set; }
		 public Guid TeamOwnerId { get; set; }
		 public string Description { get; set; }
		 public int Points { get; set; }		  
	 }
}
