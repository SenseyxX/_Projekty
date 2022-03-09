using System;
using System.Collections.Generic;
using Warehouse.Domain.Abstractions;
using Warehouse.Domain.Category.Enumeration;

namespace Warehouse.Domain.Squad.Entities
{
	 public sealed class Team : Entity
	 {
		  public Team(
			   Guid id,
			   string name,
			   Guid teamOwnerId,
			   Guid squadId,
			   string description,
			   int points,
			   State state
			   ):base (id)
		  {
			   Name = name;
			   TeamOwnerId = teamOwnerId;
			   SquadId = squadId;
			   Description = description;
			   Points = points;
			   State = state;
			   Users = new List<User.Entities.User>();
		  }

		  public string Name { get; private set; }
		  public Guid SquadId { get; }
		  public Guid TeamOwnerId { get; private set; }
		  public string Description { get; private set; }
		  public  int Points { get; private set; }
		  public State State { get; private set; }
          public ICollection<User.Entities.User> Users { get; }

          public bool UpdateName(string name)
		  {
			  if (Name == name)
			  {
				  return false;
			  }

			  Name = name;
			  return true;
		  }

		  public bool UpdateTeamOwner(Guid teamOwnerId)
		  {
			  if (TeamOwnerId == teamOwnerId)
			  {
				  return false;
			  }

			  TeamOwnerId = teamOwnerId;
			  return true;
		  }

		  public bool UpdateDescription(string description)
		  {
			   if (Description == description)
			   {
				    return false;
			   }

			   Description = description;
			   return true;
		  }

		  public bool UpdatePoints( int points)
		  {
			   if (Points == points)
			   {
				    return false;
			   }

			   Points = points;
			   return true;
		  }

		  public bool Activate()
		  {
			   if (State == State.Active)
			   {
				    return false;
			   }

			   State = State.Active;
			   return true;
		  }

		  public bool Delete()
		  {
			   if (State == State.Deleted)
			   {
				    return false;
			   }

			   State = State.Deleted;
			   return true;
		  }
	 }
}
