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
			   string description,
			   int points)
			   => new(
				    Guid.NewGuid(),
				    name,
				    teamOwnerId,
				    squadId,
				    description,
				    points = 0,
				    State.Active);
	 }
}
