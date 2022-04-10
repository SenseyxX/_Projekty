using System;
using Warehouse.Domain.Category.Enumeration;
using Warehouse.Domain.Squad.Entities;

namespace Warehouse.Domain.Squad.Factories
{
	 public static class TeamFactory
	 {
		  public static Team Create(
			   string name,
			   Guid teamOwnerId,
			   Guid squadId,
			   string description)
			   => new(
				    Guid.Empty,
				    name,
				    teamOwnerId,
				    squadId,
				    description,
				    0,
				    State.Active);
	 }
}
