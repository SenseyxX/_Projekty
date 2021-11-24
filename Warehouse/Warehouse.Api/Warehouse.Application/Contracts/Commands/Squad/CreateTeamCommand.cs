using System;

namespace Warehouse.Application.Contracts.Commands.Squad
{
	 public sealed class CreateTeamCommand
	 {
		  public string Name { get; init; }
		  public Guid TeamOwnerId { get; init; }
		  public Guid SquadId { get; set; }
		  public string Description { get; init; }
		  public int Points { get; init; }
	 }
}
