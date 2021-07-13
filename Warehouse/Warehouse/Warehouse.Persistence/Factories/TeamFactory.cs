using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Warehouse.Persistence.Entities;

namespace Warehouse.Persistence.Factories
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
				    State.Active);
	 }
}
