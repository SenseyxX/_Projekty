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
			   string description,
			   int points)
			   => new(
				    Guid.NewGuid(),
				    name,
				    teamOwnerId,
				    description,
				    points,
				    CategoryState.Active);
	 }
}
